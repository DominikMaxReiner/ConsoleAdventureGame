using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame.Utils
{
    public static class LabyrinthUtils
    {
        public static char[,] ReturnLabyrinth(ref string path)
        {
            char[,] labyrinth = new char[25, 50];

            //current position of the way in a row
            int xPos = 0;

            //new position that comes every 5 rows so there are random curves
            int wantedXPos = 0;

            Random random = new Random();

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                //every 5th row is a horizontal way to a new random position
                if (i % 5 == 0)
                {
                    wantedXPos = random.Next(0, labyrinth.GetLength(1));

                    //checks in which direction the way has to go so it can later be used in the Player class if the player needs to tell the right path
                    path = CreatePath(path, xPos, wantedXPos);

                    CreateHorizontalWay(xPos, wantedXPos, i, labyrinth);
                }
                else
                {
                    CreateVerticalWay(xPos, i, labyrinth);
                }

                //the xPos gets the value of the wantedXPos so it can be used in the next row
                xPos = wantedXPos;
            }

            //the last character of the path is not needed, so it gets removed
            path = path.Substring(0, path.Length - 1);

            return labyrinth;
        }

        private static void CreateHorizontalWay(int xPos, int wantedXPos,int i, char[,] labyrinth)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                //creates the horizontal way between the xPos and wantedXPos
                if (j >= Math.Min(xPos, wantedXPos) && j <= Math.Max(xPos, wantedXPos))
                    labyrinth[i, j] = ' ';
                else
                    labyrinth[i, j] = '#';
            }
        }

        private static void CreateVerticalWay(int xPos, int i, char[,] labyrinth)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                //if the current position is the same as the xPos, it creates a vertical way
                if (j != xPos)
                    labyrinth[i, j] = '#';
                else
                    labyrinth[i, j] = ' ';
            }
        }

        private static string CreatePath(string path, int xPos, int wantedXPos)
        {
            if (wantedXPos > xPos)
            {
                path = "lr" + path;
            }
            else if (wantedXPos < xPos)
            {
                path = "rl" + path;
            }

            return path;
        }

        public static void PrintLabyrinth(char[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write(labyrinth[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

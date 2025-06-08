using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class Endgame
    {
        public static void Endfight(Player player)
        {
            //TODO: implement the endgame fight

            Preperation(player);
        }

        private static void Preperation(Player player)
        {
            ConsoleUtils.ColorWrite("You have reached the end of the game! ", "green"); ConsoleUtils.ColorWriteLine("...but there is no way back...", "red");

            ConsoleUtils.ColorWriteLine("There is an armor. You put it on.", "green");

            player.Lives = 100; // set the player's lives to 100 for the endgame fight (due to the armor)
            player.MaximumLives = 100; // set the player's maximum lives to 100 for the endgame fight (due to the armor)
        }
    }
}

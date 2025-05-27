using ConsoleAdventureGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class AbandonedHut : Location
    {
        public AbandonedHut(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "The hut also looks very empty. An old table with a chair and lots of dust. However, there is a letter here that catches your attention:";
            ConsoleUtils.ColorWriteLine(introductionText, "gray");
        }

        protected override void PerformAction(Player player)
        {
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                { "Read the letter", () => ReadLetter(player) },
                { "Leave the hut", () => new Desert(player) }
            });
        }

        private void ReadLetter(Player player)
        {
            string letterText = "~*~ To whoever finds this ~*~\r\n\r\nThe canyon stretched endlessly ahead, the sun beating down as I finally reached the end of the ravine.\r\n\r\nBut instead of just another stretch of dry desert, something unexpected appeared. A deep, dark opening in the rock face — so well hidden that it had only become visible at the very last moment.\r\n\r\nI felt a pull. A strange curiosity that made my heart race. Without hesitation, I stepped closer.\r\n\r\nBeyond the opening lay something else. Not endless sand. Not glaring sunlight.\r\n\r\nA labyrinth, buried deep beneath the earth, darker and older than anything I had ever known.\r\n\r\nI stepped inside, full of hope, full of courage — or was it naivety? Perhaps both.\r\n\r\nThe way behind me closed, and I knew: there was no turning back.\r\n\r\nAfter I somehow managed to flee I drew this map, so whoever is braver than me can try his luck:";
            ConsoleUtils.ColorWriteLine(letterText, "darkgreen");

            LabyrinthUtils.PrintLabyrinth(player.Labyrinth, "darkgreen");

            ConsoleUtils.ColorWriteLine("— X.", "darkgreen");

            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                { "Leave the hut", () => new Desert(player) },
                { "Enter the Canyon", () => new Canyon(player) }
            });
        }
    }
}

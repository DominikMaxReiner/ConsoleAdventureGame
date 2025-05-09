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
                { "Leave the hut", () => new Canyon(player) }
            });
        }

        private void ReadLetter(Player player)
        {
            string letterText = ""; //TODO: right the letter text (+ class and method for the labyrinth)
            ConsoleUtils.ColorWriteLine(letterText, "darkgreen");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    class Canyon : Location
    {
        public Canyon(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "You see....            ....nothing. Just desert, heat, and sand. But what is that? A hut? Good luck!";

            // TODO: abandoned hut with an old letter from a deceased archaeologist -> also with a map for a labyrinth -> instructions like left;right;right.... are expected
            // TODO: a bridge that might collapse with a certain probability, alternatively fight monsters
            // TODO: rockfall that can only be passed with a car, otherwise vehicle is lost or death (if no vehicle is present)


            ConsoleUtils.ColorWriteLine(introductionText, "gray");
        }

        protected override void PerformAction(Player player)
        {
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                { "Enter the abondoned hut", () => new AbandonedHut(player) },
                { "Flee to the village", () => new Village(player) }
        });
        }
    }
}

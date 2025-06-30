using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    class Desert : Location
    {
        public Desert(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "You see....            ....nothing. Just desert, heat, and sand. But what is that? A hut? Good luck!";

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

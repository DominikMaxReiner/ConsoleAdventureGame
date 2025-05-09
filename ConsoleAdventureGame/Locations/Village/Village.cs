using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Village : Location
    {
        public Village(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "Welcome to the village! It is safe here, and you have many options: you can buy a vehicle at the vehicle dealer, refuel it, get yourself a weapon, or work at the vehicle dealer if you need coins. Have fun!";

            ConsoleUtils.ColorWriteLine(introductionText, "gray");
        }

        protected override void PerformAction(Player player)
        {
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"Go to the VehicleStore", () => new VehicleStore(player) },
                {"Go to the WeaponSmith", () => new Weaponsmith(player) },
                {"Go to the GasStation", () => new GasStation(player) },
                {"Go to the Canyon", () => new Canyon(player) },
                {"Go into the DarkForest", () => new DarkForest(player) }
            });
        }
    }
}

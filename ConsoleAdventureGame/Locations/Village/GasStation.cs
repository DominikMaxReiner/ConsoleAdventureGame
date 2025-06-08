using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class GasStation : Location // TODO: check if this class is needed
    {
        public GasStation(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "Welcome to the GasStation!";

            Dialog.ShowMessage("Employee", introductionText, "cyan");
        }

        protected override void PerformAction(Player player)
        {
            player.CurrentVehicle.TankLevel += InteractionUtils.PerformTransaction(player, player.CurrentVehicle != null, $"How much would you like to refuel your {player.CurrentVehicle?.Name}? (Price: 1 coin = 1 liter)", "You don't own a vehicle.");
            _ = new Village(player);
        }
    }
}

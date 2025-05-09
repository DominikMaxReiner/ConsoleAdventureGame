using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class VehicleStore : Location
    {
        public VehicleStore(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "Welcome to the VehicleStore! Are you here for the job, or do you want to buy a vehicle?";

            Dialog.ShowMessage("Vehicle Dealer", introductionText, "cyan");
        }

        protected override void PerformAction(Player player)
        {
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"I want to buy a vehicle" , () => BuyAVehicle(player)},
                {"I'm here for the Job" , () => JobInterview(player)},
                {"Go back to the village" , () => new Village(player)}
            });
        }

        private void BuyAVehicle(Player player)
        {
            Dialog.ShowMessage("Vehicle Dealer", $"Which vehicle would you like to buy? The car costs {new Car().Price} coins, the airplane costs {new Airplane().Price} coins, and the tank costs {new Tank().Price} coins. Please note that your old vehicle will be scrapped. You can use //v to access information about your vehicle.", "cyan");

            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"Buy the car" , () => BuyAVehicleTransaction(player, new Car())},
                {"Buy the plane" , () => BuyAVehicleTransaction(player, new Airplane())},
                {"Buy the tank" , () => BuyAVehicleTransaction(player, new Tank())},
                {"I don't want to buy a vehicle" , () => new VehicleStore(player)}
            });
        }

        private void BuyAVehicleTransaction(Player player, Vehicle vehicle)
        {
            Vehicle currentVehicle = player.CurrentVehicle;
            InteractionUtils.BuySomething<Vehicle>(player, vehicle.Price, vehicle, ref currentVehicle);
            player.CurrentVehicle = currentVehicle;
            _ = new VehicleStore(player);
        }

        private void JobInterview(Player player)
        {
            while (true)
            {
                Dialog.ShowMessage("Vehicle Dealer", "You can start working here right away. You will receive 1/3 of the purchase value of the products you sell as payment.", "cyan");

                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    {"I want to start" , () => VehicleStoreJob(player)},
                    {"I've changed my mind" , () => new VehicleStore(player)}
                });
            }
        }

        private void VehicleStoreJob(Player player)
        {
            while(true)
            {
                _ = new Customer(player);
            }
        }
    }
}

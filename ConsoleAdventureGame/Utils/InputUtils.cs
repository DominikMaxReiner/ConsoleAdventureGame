using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    static class InputUtils
    {
        public static Player? CurrentPlayer { get; set; }

        static public void GetPlayerInput(Dictionary<string, Action> optionTexts) //creates the Dictionary for the player input based on the passed Dictionary of strings and Options
        {
            var inputOptions = optionTexts.Keys.ToList();

            ShowInputOptions(inputOptions, "magenta");
            Console.WriteLine();

            var actionOptions = new Dictionary<int, Action>();

            for (int i = 0; i < optionTexts.Count; i++)
            {
                actionOptions[i] = optionTexts[inputOptions[i]];
            }

            ProcessPlayersDecision(actionOptions);
        }

        static private void ShowInputOptions(List<string> inputOptions, string color) // shows the options for the player
        {
            ConsoleUtils.ColorWriteLine("Your input for the next move: ", color);
            Console.WriteLine();
            for (int i = 0; i < inputOptions.Count; i++)
            {
                ConsoleUtils.ColorWriteLine($"[{i}] {inputOptions[i]}", color);
            }
        }

        static private void ProcessPlayersDecision(Dictionary<int, Action> actionOptions)
        {
            while(true)
            {
                string playersInput = Console.ReadLine();
                int playersDecision = 0;

                if (int.TryParse(playersInput, out playersDecision)) // if the input is a valid number the according Action gets executed
                {
                    if (actionOptions.ContainsKey(playersDecision))
                    {
                        actionOptions[playersDecision]();
                        break;
                    }
                }
                else // if the input is not a valid number, it checks if the input is a command for player data
                {
                    ShowPlayerData(playersInput, CurrentPlayer);
                }
            }
        }

        static private void ShowPlayerData(string playersInput, Player player)
        {
            switch (playersInput)
            {
                case "//l":
                    ConsoleUtils.ColorWriteLine($"Lives: {CurrentPlayer?.Lives}", "yellow");
                    break;
                case "//c":
                    ConsoleUtils.ColorWriteLine($"Coins: {CurrentPlayer?.Coins}", "yellow");
                    break;
                case "//k":
                    ConsoleUtils.ColorWriteLine($"Keys: {CurrentPlayer?.AmountOfKeys}", "yellow");
                    break;
                case "//v":
                    ConsoleUtils.ColorWriteLine($"Vehicle: {CurrentPlayer?.CurrentVehicle?.Name}", "yellow");
                    ConsoleUtils.ColorWriteLine($"Lives: {CurrentPlayer?.CurrentVehicle?.Lives}", "yellow");
                    ConsoleUtils.ColorWriteLine($"Speed: {CurrentPlayer?.CurrentVehicle?.Speed}", "yellow");
                    ConsoleUtils.ColorWriteLine($"CanShoot: {CurrentPlayer?.CurrentVehicle?.CanShoot}", "yellow");
                    ConsoleUtils.ColorWriteLine($"CanFly: {CurrentPlayer?.CurrentVehicle?.CanFly}", "yellow");
                    ConsoleUtils.ColorWriteLine($"FuelLevel: {CurrentPlayer?.CurrentVehicle?.TankLevel}", "yellow");
                    ConsoleUtils.ColorWriteLine($"FuelConsomption: {CurrentPlayer?.CurrentVehicle?.FuelConsumption}", "yellow");
                    break;
                case "//w":
                    ConsoleUtils.ColorWriteLine($"Weapon: {CurrentPlayer?.CurrentWeapon?.Name}", "yellow");
                    ConsoleUtils.ColorWriteLine($"Damage: {CurrentPlayer?.CurrentWeapon?.Damage}", "yellow");
                    ConsoleUtils.ColorWriteLine($"CanShoot: {CurrentPlayer?.CurrentWeapon?.CanShoot}", "yellow"); // TODO: check if this is needed
                    if (player.OwnsBow)
                    {
                        Console.WriteLine();
                        ConsoleUtils.ColorWriteLine("You own a bow.", "yellow");
                        ConsoleUtils.ColorWriteLine($"Arrows: {CurrentPlayer?.ArrowAmount}", "yellow");
                    }
                    break;
            }
        }


        static public int GetPlayerInputNumber()
        {
            int inputNumber;
            
            while (true)
            {
                string inputText = Console.ReadLine();

                if (int.TryParse(inputText, out inputNumber))
                    return inputNumber;
                else
                    ShowPlayerData(inputText, CurrentPlayer);
            }

        }
    }
}

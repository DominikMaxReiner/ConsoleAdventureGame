using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// Provides utility methods for handling player input in the game (other than Attacking)
    /// </summary>
    static class InputUtils
    {
        /// <summary>The player, whos information will be shown.</summary>
        public static Player? CurrentPlayer { get; set; }

        /// <summary>
        /// Displays a numbered list of options to the player and processes their input.
        /// </summary>
        /// <param name="optionTexts">
        /// A dictionary where each key is the option text to display,
        /// and the corresponding value is the action to execute when selected.
        /// </param>
        /// <remarks>
        /// This method shows the input options, maps them to numeric choices,
        /// processes the player's input, and executes the selected action.
        /// If the input is not a number, it checks for special commands to display player data.
        /// </remarks>
        public static void GetPlayerInput(Dictionary<string, Action> optionTexts) //creates the Dictionary for the player input based on the passed Dictionary of strings and Options
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

        // Writes a prompt and then lists all input options with their index in the specified color
        private static void ShowInputOptions(List<string> inputOptions, string color) // shows the options for the player
        {
            ConsoleUtils.ColorWriteLine("Your input for the next move: ", color);
            Console.WriteLine();
            for (int i = 0; i < inputOptions.Count; i++)
            {
                ConsoleUtils.ColorWriteLine($"[{i}] {inputOptions[i]}", color);
            }
        }

        // Loop until the player enters a valid number corresponding to an action or a recognized command
        // If a valid number is entered, execute the associated action and exit the loop
        // Otherwise, treat input as a command and show player data accordingly
        private static void ProcessPlayersDecision(Dictionary<int, Action> actionOptions)
        {
            while(true)
            {
                string playersInput = Console.ReadLine();
                int playersDecision = 0;

                // Try to parse number and execute action
                if (int.TryParse(playersInput, out playersDecision)) // If the input is a valid number the according Action gets executed
                {
                    if (actionOptions.ContainsKey(playersDecision))
                    {
                        actionOptions[playersDecision]();
                        break;
                    }
                }
                else // If the input is not a valid number, it checks if the input is a command for player data
                {
                    // Interpret input as a special player data command
                    ShowPlayerData(playersInput, CurrentPlayer);
                }
            }
        }

        // Display specific player info based on the entered command string (e.g. "//l" for lives)
        // Shows various stats like lives, coins, keys, vehicle info or weapon info depending on the command
        private static void ShowPlayerData(string playersInput, Player player)
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
                    ConsoleUtils.ColorWriteLine($"CanShoot: {CurrentPlayer?.CurrentVehicle?.CanShoot}", "yellow");
                    ConsoleUtils.ColorWriteLine($"CanFly: {CurrentPlayer?.CurrentVehicle?.CanFly}", "yellow");
                    break;
                case "//w":
                    ConsoleUtils.ColorWriteLine($"Weapon: {CurrentPlayer?.CurrentWeapon?.Name}", "yellow");
                    ConsoleUtils.ColorWriteLine($"Damage: {CurrentPlayer?.CurrentWeapon?.Damage}", "yellow");
                    if (player.OwnsBow)
                    {
                        Console.WriteLine();
                        ConsoleUtils.ColorWriteLine("You own a bow.", "yellow");
                        ConsoleUtils.ColorWriteLine($"Arrows: {CurrentPlayer?.ArrowAmount}", "yellow");
                    }
                    break;
            }
        }

        /// <summary>
        /// Asks the player for a numeric input and repeats the prompt until a valid number is entered.
        /// </summary>
        /// <returns>The valid number entered by the player.</returns>
        public static int GetPlayerInputNumber()
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

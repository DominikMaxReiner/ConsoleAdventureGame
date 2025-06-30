using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Temple : Location
    {
        public Temple(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "You are now at the temple. Here you can find a key to overcome the next challenge. But be careful, there are many dangers!";

            ConsoleUtils.ColorWriteLine(introductionText, "gray");
        }

        protected override void PerformAction(Player player)
        {
            ConsoleUtils.ColorWriteLine("You are standing in front of the temple: ", "gray");

            DrawTemple();

            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"Enter the temple", () => InsideTemple(player) },
                {"Flee to the village", () => new Village(player) },
                {"Destroy the temple", () => TryDestroyTemple(player)}
            });

            if(!player.TempleKeyFound)
            {
                player.TempleKeyFound = true;
                KeyManager.AddKey(player);
            }
        }

        private void DrawTemple()
        {
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtils.ColorWriteLine("         ^", "yellow");
            ConsoleUtils.ColorWriteLine("        / \\", "yellow");
            ConsoleUtils.ColorWriteLine("       /   \\", "yellow");
            ConsoleUtils.ColorWriteLine("      /     \\", "yellow");
            ConsoleUtils.ColorWriteLine("     /_______\\", "yellow");
            ConsoleUtils.ColorWriteLine("     |       |", "gray");
            ConsoleUtils.ColorWriteLine("     |  ___  |", "gray");
            ConsoleUtils.ColorWriteLine("     | |   | |", "gray");
            ConsoleUtils.ColorWriteLine("     | |___| |", "gray");
            ConsoleUtils.ColorWriteLine("     |_______|", "gray");
            Console.WriteLine();
            Console.WriteLine();
        }

        // In the temple, the player can either fight enemies or destroy the temple if they have a vehicle that can shoot.
        private void InsideTemple(Player player)
        {
            if(!player.ReachedTempleKeyFight)
            {
                Fight.PerformFight(player, new Guardian());

                Fight.SequenceOfRandomFights(player, new List<Enemy> { new Spider(), new Serpent(player) }, 3);
            }
            
            player.ReachedTempleKeyFight = true;

            if(!player.TempleKeyFound)
            {
                KeyFight(player);
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You have already completed the temple", "gray");
            }
        }

        // The final fight of the Temple and DarkForest, where the player fights against a Guardian, Spider, and Serpent.
        private void KeyFight(Player player)
        {
            Fight.PerformMultipleEnemyFight(player, new List<Enemy> { new Guardian(), new Spider(), new Serpent(player) });
        }

        // The method to destroy the temple, which can only be done if the player has a vehicle that can shoot.
        private void TryDestroyTemple(Player player)
        {
            if(player.CurrentVehicle != null && player.CurrentVehicle.CanShoot)
            {
                ConsoleUtils.ColorWriteLine("You have destroyed the temple.", "gray");
                player.DestroyedTemple = true;
                KeyManager.AddKey(player);
                _ = new Village(player);
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have a vehicle that can shoot.", "red");
                
                PerformAction(player);
            }
        }
    }
}

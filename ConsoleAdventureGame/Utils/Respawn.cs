using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// Provides functionality to handle player respawning after death.
    /// </summary>
    public static class Respawn
    {
        /// <summary>
        /// Resets the player's state after death and respawns them in the village.
        /// </summary>
        /// <param name="player">The player who is being respawned.</param>
        public static void RespawnPlayer(Player player)
        {
            ConsoleUtils.ColorWriteLine("You died! You will respawn in the village.", "white");
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
            Console.WriteLine();

            player.Coins = 0;
            player.Lives = 10;
            player.MaximumLives = 10;
            player.CurrentWeapon = null;
            player.ArrowAmount = 0;
            player.CurrentVehicle = null;
            player.OwnsBow = false;

            // Reposition the player in the village
            _ = new Village(player);
        }
    }
}

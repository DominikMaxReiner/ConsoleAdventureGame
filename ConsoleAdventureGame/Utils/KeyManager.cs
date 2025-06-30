using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// This static class manages the handling of the player's keys in the game.
    /// </summary>
    public static class KeyManager
    {
        /// <summary>
        /// Adds a key to the player's inventory and notifies them.
        /// </summary>
        /// <param name="player">The player who gets a key.</param>
        public static void AddKey(Player player)
        {
            ConsoleUtils.ColorWriteLine("You received another Key: ", "gray");
            player.AmountOfKeys += 1;
        }
    }
}

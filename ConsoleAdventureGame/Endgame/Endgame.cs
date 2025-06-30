using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// Includes every functionality for the endgame of the game.
    /// </summary>
    public static class Endgame
    {
        /// <summary>
        /// Prepares the player with Preperation() and then starts the endgame fight against the Undead King.
        /// </summary>
        /// <param name="player">The player who gets to the endgame.</param>
        public static void Endfight(Player player)
        {
            Preperation(player);

            Fight.PerformFight(player, new UndeadKing(), false);
        }

        // Intorduces the player to the endgame.
        // Gives the player more lives for an more exciting endgame fight.
        private static void Preperation(Player player)
        {
            ConsoleUtils.ColorWrite("You have reached the end of the game! ", "green"); ConsoleUtils.ColorWriteLine("...but there is no way back...", "red");

            ConsoleUtils.ColorWriteLine("There is an armor. You put it on.", "green");

            player.Lives = 150; // set the player's lives to 150 for the endgame fight (due to the armor)
            player.MaximumLives = 150; // set the player's maximum lives to 150 for the endgame fight (due to the armor)
        }
    }
}

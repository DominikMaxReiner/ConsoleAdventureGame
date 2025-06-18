using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class Endgame
    {
        public static void Endfight(Player player)
        {
            //TODO: implement the endgame fight

            Preperation(player);

            Fight.PerformFight(player, new UndeadKing(), false);
        }

        private static void Preperation(Player player)
        {
            ConsoleUtils.ColorWrite("You have reached the end of the game! ", "green"); ConsoleUtils.ColorWriteLine("...but there is no way back...", "red");

            ConsoleUtils.ColorWriteLine("There is an armor. You put it on.", "green");

            player.Lives = 150; // set the player's lives to 150 for the endgame fight (due to the armor)
            player.MaximumLives = 150; // set the player's maximum lives to 150 for the endgame fight (due to the armor)
        }
    }
}

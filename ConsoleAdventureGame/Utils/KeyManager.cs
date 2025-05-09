using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class KeyManager
    {
        public static void AddKey(Player player)
        {
            ConsoleUtils.ColorWriteLine("You received another Key: ", "gray");
            player.AmountOfKeys += 1;
            if (player.AmountOfKeys == 3)
                Endgame.Endfight(player);
        }
    }
}

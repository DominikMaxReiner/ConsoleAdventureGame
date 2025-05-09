using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class Respawn
    {
        public static void RespawnPlayer(Player player)
        {
            player.Coins = 0;
            player.Lives = 10;
            player.CurrentWeapon = null;
            player.ArrowAmount = 0;
            player.CurrentVehicle = null;
            player.OwnsBow = false;

            _ = new Village(player);
        }
    }
}

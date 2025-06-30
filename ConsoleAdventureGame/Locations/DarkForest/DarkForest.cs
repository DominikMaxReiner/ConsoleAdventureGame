using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    class DarkForest : Location
    {
        public DarkForest(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "You are now in the darkest forest of the region. Here you will encounter traps and enemies, as well as a forest mansion. In the forest mansion, you can find a key. Good luck!";

            ConsoleUtils.ColorWriteLine(introductionText, "gray");
        }

        /// <summary>
        /// In the DarkForest, the Action is the way to the temple.
        /// On the way, the player encounters random enemies using the <see cref="Fight"/ class>.
        /// If the player has a vehicle that can fly, they can skip the fights and go directly to the temple.
        /// </summary>
        protected override void PerformAction(Player player)
        {
            if(player.CurrentVehicle != null)
            {
                if (!player.CurrentVehicle.CanFly)
                    WayToTemple(player);
            }
            else
            {
                WayToTemple(player);
            }

            if (!player.DestroyedTemple)
            {
                _ = new Temple(player);
            }
            else
            {
                ConsoleUtils.ColorWriteLine("There used to be a temple here...", "gray");
                _ = new Village(player);
            }

            _ = new Village(player);
        }

        // This method handles the way to the temple, where the player encounters random enemies.
        private void WayToTemple(Player player)
        {
            Fight.SequenceOfRandomFights(player, new List<Enemy> { new Zombie(), new Golem(), new Werewolf() }, 5);
        }
    }
}

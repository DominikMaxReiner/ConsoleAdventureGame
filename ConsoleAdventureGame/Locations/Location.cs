using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// The abstract class Location represents any location in the game.
    /// </summary>
    public abstract class Location
    {
        /// <summary>
        /// The Introduction() and PerformAction() methods are called.
        /// Therefore, the player gets introduced and is located in the location automatically if a Location-object is created.
        /// </summary>
        /// <param name="player">The player who acts in the location.</param>
        public Location(Player player)
        {
            Introduction();
            ConsoleUtils.ColorWriteLine("---------------", "gray");
            PerformAction(player);
        }

        /// <summary>The Introduction() method is called to output an introduction text.</summary>
        protected abstract void Introduction();

        /// <summary>In the PerformAction() method the whole logic of the location is implemented. (normally in the first step the player can only choose to go to a sublocation)</summary>
        protected abstract void PerformAction(Player player);
    }
}

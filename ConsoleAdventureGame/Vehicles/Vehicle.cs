using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// The abstract class Vehicle represents any vehicle in the game.
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>The name of the vehicle.</summary>
        public abstract string Name { get; }
        /// <summary>The amount of coins the player has to pay for the vehicle.</summary>
        public abstract int Price { get; set; }
        /// <summary>A flag that indicates if the vehicle can fly.</summary>
        public abstract bool CanFly { get; }
        /// <summary>A flag that indicates if the vehicle can shoot.</summary>
        public abstract bool CanShoot { get; }
        /// <summary>The amount of lives the vehicle has initially.</summary>
        public abstract int Lives { get; set; }
    }
}

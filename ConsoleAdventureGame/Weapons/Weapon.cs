using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// The abstract class Weapon represents any weapon in the game.
    /// </summary>
    public abstract class Weapon
    {
        /// <summary>The name of the weapon.</summary>
        public abstract string Name { get; }
        /// <summary>The amount of coins the player has to pay for the weapon.</summary>
        public abstract int Price { get; }
        /// <summary>The damage that the weapon is capable to deal.</summary>
        public abstract int Damage { get; set; }
        /// <summary>A flag that indicates if the weapon can shoot.</summary>
        public abstract bool CanShoot { get; }
    }
}

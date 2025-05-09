using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public abstract class Weapon
    {
        public abstract string Name { get; }
        public abstract int Price { get; }
        public abstract int Damage { get; }
        public abstract bool CanShoot { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public abstract class Vehicle
    {
        public abstract string Name { get; }
        public abstract int Price { get; set; }
        public abstract bool CanFly { get; }
        public abstract bool CanShoot { get; }
        public abstract int Speed { get; }
        public abstract int Lives { get; set; }
        public abstract int TankLevel { get; set; } // Tank level can be infinite and is set to 100 by default -> Reference consumption rate is 10L/100km (for an airplane only 3L, for a tank 100L)
        public abstract int FuelConsumption { get; }
    }
}

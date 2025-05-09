using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Airplane : Vehicle
    {
        public override string Name { get; } = "Airplane";
        public override int Price { get; set; } = 1000;
        public override bool CanFly { get; } = true;
        public override bool CanShoot { get; } = false;
        public override int Speed { get; } = 700;
        public override int Lives { get; set; } = 100;
        public override int TankLevel { get; set; } = 100;
        public override int FuelConsumption { get; } = 3;
    }
}

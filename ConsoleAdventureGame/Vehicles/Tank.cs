using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Tank : Vehicle
    {
        public override string Name { get; } = "Tank";
        public override int Price { get; set; } = 1100;
        public override bool CanFly { get; } = false;
        public override bool CanShoot { get; } = true;
        public override int Speed { get; } = 50;
        public override int Lives { get; set; } = 500;
        public override int TankLevel { get; set; } = 100;
        public override int FuelConsumption { get; } = 50;

        public int Damage { get; } = 150;
    }
}

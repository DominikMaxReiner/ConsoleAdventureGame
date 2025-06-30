using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Car : Vehicle
    {
        public override string Name { get; } = "Car";
        public override int Price { get; set; } = 200;
        public override bool CanFly { get; } = false;
        public override bool CanShoot { get; } = false;
        public override int Lives { get; set; } = 200;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Bow : Weapon
    {
        public override string Name { get; } = "Bow";
        public override int Price { get; } = 150;
        public override int Damage { get; set; } = 10;
        public override bool CanShoot { get; } = true;
    }
}

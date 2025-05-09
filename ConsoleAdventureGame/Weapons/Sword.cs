using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Sword : Weapon
    {
        public override string Name { get; } = "Sword";
        public override int Price { get; } = 100;
        public override int Damage {get; } = 30;
        public override bool CanShoot { get; } = false;
    }
}

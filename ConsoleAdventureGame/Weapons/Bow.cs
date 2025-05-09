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
        public override int Damage { get; } = 30;
        public override bool CanShoot { get; } = true;

        public void Attack(Enemy enemy)
        {
            //TODO: implement Bow Attack (maybe delete bow from game: has not a use yet)
        }
    }
}

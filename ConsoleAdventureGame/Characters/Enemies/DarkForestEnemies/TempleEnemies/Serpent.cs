using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Serpent : Enemy
    {
        public Serpent(Player player)
        {
            Task.Run(() => Poison(player));
        }

        public override string Name { get; } = "Serpent";

        public override int Lives { get; set; } = 160;

        public override int Damage { get; } = 35;

        public override int CriticalHitChance { get; } = 6;

        public override int CriticalDamage { get; } = 60;

        private void Poison(Player player)
        {
            Dialog.ShowMessage(Name, "You got poisoned!", "darkred");

            for (int i = 0; i < 10; i++)
            {
                player.Lives -= 1;
                Thread.Sleep(5000);
            }
        }
    }
}

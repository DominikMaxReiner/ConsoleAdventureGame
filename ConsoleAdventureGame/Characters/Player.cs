using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleAdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Lives { get; set; } = 10; //always set to 10 by default
        public int Coins { get; set; } = 10; //always set to 10 by default
        public Weapon? CurrentWeapon { get; set; }
        public bool OwnsBow { get; set; } = false; //always set to false by default
        public int ArrowAmount { get; set; } = 0; //always set to 0 by default
        public Vehicle? CurrentVehicle { get; set; }
        public int AmountOfKeys { get; set; } = 0; //always set to 0 by default

        public bool DestroyedTemple { get; set; } = false; //always set to false by default
        public bool TempleKeyFound { get; set; } = false; //always set to false by default
        public bool ReachedTempleKeyFight { get; set; } = false; //always set to false by default

        public Player(string name)
        {
            Name = name;
        }

        public void PerformAttack(Enemy enemy) => Attack.ExecuteAttack(this, enemy);

        public void PerformBowAttack(Enemy enemy) => new Bow().Attack(enemy);
    }
}

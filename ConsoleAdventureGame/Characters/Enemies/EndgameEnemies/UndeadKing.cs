using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// The UndeadKing class represents the final boss of the game.
    /// </summary>
    public class UndeadKing : Enemy
    {
        private bool AttacksOnHisOwn { get; set; } = false; // if the lives get udner 100, the Undead King attacks on his own -> at the transition (but only one time) he sais that he got mad now

        private int _maxLives = 200;

        public override string Name { get; } = "UNDEAD KING";

        // needs a backing field to store the lives, because the setter of Lives is overridden to show the boss bar when lives are changed.
        private int _lives = 200; // Undead King starts with 200 lives
        public override int Lives 
        {
            get => _lives; 
            set
            {
                _lives = value;
                ShowBossBar(); // refresh the boss bar when lives are changed
            }
        }

        public override int Damage { get; } = 40;

        public override int CriticalHitChance { get; } = 2;

        public override int CriticalDamage { get; } = 60;

        /// <summary>
        /// If Undead King attacks the player, he either summons his minions (if Lives >= 100) or attacks on his own (if Lives < 100).
        /// </summary>
        /// <param name="player">The player who gets attacked.</param>
        public override void PerformAttack(Player player)
        {
            if (Lives >= 100)
            {
                Dialog.ShowMessage(Name, $"I summoned my minions!! They have their own special abilities...", "darkred");
                SummonMinions(player);
            }
            else
            {
                if (!AttacksOnHisOwn) // if the Undead King has not attacked on his own yet
                {
                    AttacksOnHisOwn = true; // set the flag to true, so he only attacks on his own once
                    Dialog.ShowMessage(Name, "I have gone mad now! I attack you on my own now!", "darkred");
                }
                PerformOwnAttack(player);
            }
        }

        // Starts a figth between the player and the Undead King's minions (UndeadMage, ShieldWarrior).
        private void SummonMinions(Player player)
        {
            // Logic to summon minions with an own fight
            Fight.PerformMultipleEnemyFight(player, new List<Enemy>
            {
                new UndeadMage(),
                new ShieldWarrior()
            }, false);

            // sets the player's weapon damage to the default value (important if the player got cursed by the UndeadMage)
            Type weaponType = player.CurrentWeapon.GetType();
            Weapon defaultWeapon = (Weapon)Activator.CreateInstance(weaponType)!;
            player.CurrentWeapon.Damage = defaultWeapon.Damage;

            player.CanRegenarateLives = true; // after a fight against the minions the player can regenerate lives again
        }

        // The Undead King has a chance to heal himself when attacking the player.
        private void PerformOwnAttack(Player player)
        {
            base.PerformAttack(player);
            Random random = new Random();

            //the Undead King has a chance to heal himself when attacking
            if (random.Next(0, 2) == 1)
            {
                int regeneration = (200 - Lives) / 8;
                Lives += regeneration;
                Dialog.ShowMessage(Name, $"You hit me, but I have healed myself! I got {regeneration} lives.", "darkred");
            }
        }

        // Outputs the boss bar to the console, showing the current lives of the Undead King.
        private void ShowBossBar()
        {
            //Console.Clear();
            ConsoleUtils.ColorWrite("BOSS BAR: ", "red");

            int maxBar = 50;
            int bossBarDevider = _maxLives / maxBar; // 200 lives / 50 characters = 4 lives per character

            // boss bar should only be 50 characters wide
            for (int i = 0; i < maxBar; i++)
            {
                if (i < maxBar/2 && i <= Lives / bossBarDevider)
                {
                    ConsoleUtils.ColorWrite("█", "red");
                }
                else if(i <= Lives / bossBarDevider)
                {
                    ConsoleUtils.ColorWrite("█", "green");
                }
                else
                {
                    ConsoleUtils.ColorWrite("█", "gray");
                }
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

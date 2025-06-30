using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// Provides static methods to execute attacks from players and enemies,
    /// including aiming mechanics and damage calculations.
    /// </summary>
    public static class Attack
    {
        // Flag to track if the Enter key was pressed during aiming
        private static bool EnterPressed { get; set; }

        /// <summary>
        /// Executes an attack by the player on the specified enemy using the current weapon.
        /// Calculates damage based on aiming and updates the enemy's lives accordingly.
        /// </summary>
        /// <param name="player">The player performing the attack.</param>
        /// <param name="enemy">The enemy being attacked.</param>
        public static void ExecuteAttack(Player player, Enemy enemy)
        {
            if (player.CurrentWeapon != null)
            {
                int damage = Aim(player.CurrentWeapon);
                enemy.Lives -= damage;

                player.LastDealtDamage = damage; //used to reflect the players damge in a figth against the ShieldWarrior

                enemy.ShowLives();
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have a weapon to attack with!", "red");
            }
        }

        // Starts the aiming process and returns the damage dealt based on timing.
        private static int Aim(Weapon weapon)
        {
            EnterPressed = false;

            Console.Clear();

            string hitbar = "++++++++++++++++++++";
            ConsoleUtils.ColorWriteLine(hitbar, "gray");

            var HitbarComponents = new List<ColorTextObjects>
            {
                {new ColorTextObjects("++++++++++", "white")},
                {new ColorTextObjects("+++++", "green")},
                {new ColorTextObjects("++", "red")},
                {new ColorTextObjects("+++", "white")},
            };

            // Start a task to capture the player's input

            IsEnterPressed();

            return ShowHitbar(HitbarComponents, weapon);
        }

        // Asynchronously listens for the Enter key press and sets EnterPressed flag
        private static void IsEnterPressed()
        {
            Task.Run(() =>
            {
                while (!EnterPressed)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            EnterPressed = true;
                        }
                    }
                }
            });
        }

        // Displays the hitbar and calculates damage based on where Enter was pressed
        private static int ShowHitbar(List<ColorTextObjects> hitbarComponents, Weapon weapon)
        {
            int damage = 0;

            int position = 0;
            for (int i = 0; i < hitbarComponents.Count; i++)
            {
                for (int j = 0; j < hitbarComponents[i].Text.Length; j++)
                {
                    Console.SetCursorPosition(position, 0);
                    ConsoleUtils.ColorWrite(Convert.ToString(hitbarComponents[i].Text[j]), hitbarComponents[i].Color);
                    Thread.Sleep(200); //wait 200ms
                    position++;

                    if (EnterPressed)
                    {
                        damage = ReturnDamage(i, weapon);
                        return damage;
                    }
                }
            }
            Console.WriteLine();
            return damage;
        }

        // Determines the damage based on the hitbar segment index
        private static int ReturnDamage(int i, Weapon weapon)
        {
            int damage = 0;

            if (i == 0 || i == 3)
            {
                damage = weapon.Damage;
                ConsoleUtils.ColorWriteLine($"You dealt {damage} damage!", "green");
            }
            else if (i == 1)
            {
                damage = weapon.Damage + weapon.Damage / 2;
                ConsoleUtils.ColorWriteLine($"You dealt {damage} damage!", "yellow");
            }
            else if (i == 2)
            {
                damage = 0;
                ConsoleUtils.ColorWriteLine("You missed!", "red");
            }

            return damage;
        }


        /// <summary>
        /// Calculates the damage an enemy deals to the player,
        /// taking into account the enemy's critical hit chance.
        /// </summary>
        /// <param name="enemy">The attacking enemy.</param>
        /// <returns>The amount of damage dealt.</returns>
        public static int ReturnEnemyAttackDamage(Enemy enemy)
        {
            Random random = new Random();
            int damageMuliplicator = random.Next(1, enemy.CriticalHitChance + 1);

            if (damageMuliplicator == enemy.CriticalHitChance)
            {
                Dialog.ShowMessage(enemy.Name, $"I landed a critical hit! You took {enemy.CriticalDamage} damage!", "darkred");
                return enemy.CriticalDamage;
            }
            else
            {
                Dialog.ShowMessage(enemy.Name, $"You took {enemy.Damage} damage!", "darkred");
                return enemy.Damage;
            }
        }

        /// <summary>
        /// Executes a bow attack by the player on the specified enemy,
        /// if the player owns a bow and has arrows.
        /// </summary>
        /// <param name="player">The player performing the attack.</param>
        /// <param name="enemy">The enemy being attacked.</param>
        public static void ExecuteBowAttack(Player player, Enemy enemy)
        {
            if (player.OwnsBow && player.ArrowAmount > 0)
            {
                int damage = AimWithBow();
                enemy.Lives -= damage;
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have a bow or arrows to attack with!", "red");
            }
        }

        // Handles aiming mechanic for bow attacks and returns damage dealt
        private static int AimWithBow()
        {
            bool successfullHit = false;
            EnterPressed = false;

            IsEnterPressed(); // Start a task to capture the player's input

            string hitbar = "[         ||||         ]";
            for (int i = 0; i < hitbar.Length; i++)
            {
                Console.Clear();

                Console.Write(hitbar.Substring(0, i));

                ConsoleUtils.ColorWrite("-", "green");
                
                Console.Write(hitbar.Substring(i, hitbar.Length - i));

                if (EnterPressed)
                {
                    if (i == (hitbar.Length / 2) + 1 || i == hitbar.Length / 2 || i == (hitbar.Length / 2) - 1 || i == (hitbar.Length / 2) - 2)
                    {
                        successfullHit = true; // if the player hits the target
                        ConsoleUtils.ColorWriteLine("You hit the target!", "green");
                    }
                    else
                        ConsoleUtils.ColorWriteLine("You missed!", "red");

                    break;
                }

                Thread.Sleep(145); // wait 145 ms
            }

            if (successfullHit)
            {
                ConsoleUtils.ColorWriteLine("You hit the target!", "green");
                return new Bow().Damage;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Special method to handle bow attacks on the Undead King.
        /// Restricts bow usage when the Undead King's lives are below a threshold.
        /// </summary>
        /// <param name="player">The player attacking the Undead King.</param>
        /// <param name="undeadKing">The Undead King enemy.</param>
        public static void AttackUndeadKingWithBow(Player player, UndeadKing undeadKing)
        {
            if(undeadKing.Lives <= 100)
            {

                Dialog.ShowMessage(undeadKing.Name, "I have enough of this. You should fight with your sword!", "darkred");
                ConsoleUtils.ColorWriteLine("You feel a force tear your bow out of your hands", "white");
                player.CanAttackUndeadKingWithBow = false;

                ConsoleUtils.ColorWriteLine("Are you ready for the next stage? Then press Enter, but you hae to attack with your Sword from now on.", "white");
                Console.ReadKey();
                return;
            }
            else
            {
                player.PerformBowAttack(undeadKing);
            }
        }
    }
}

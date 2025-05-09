using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleAdventureGame
{
    public static class Attack
    {
        private static bool EnterPressed { get; set; }

        public static void ExecuteAttack(Player player, Enemy enemy)
        {
            if (player.CurrentWeapon != null)
            {
                enemy.Lives -= Aim(enemy, player.CurrentWeapon);
                enemy.ShowLives();
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have a weapon to attack with!", "red");
            }
        }

        private static int Aim(Enemy enemy, Weapon weapon)
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
                Dialog.ShowMessage(enemy.Name, $"You took {enemy.CriticalDamage} damage!", "darkred");
                return enemy.Damage;
            }
        }
    }
}

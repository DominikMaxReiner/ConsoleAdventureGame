using ConsoleAdventureGame.Utils;
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
        /// Properties
        public string Name { get; set; }
        public int Lives { get; set; } = 10; //always set to 10 by default
        public int Coins { get; set; } = 10; //always set to 10 by default
        public Weapon? CurrentWeapon { get; set; }
        public bool OwnsBow { get; set; } = false; //always set to false by default
        public int ArrowAmount { get; set; } = 0; //always set to 0 by default
        public Vehicle? CurrentVehicle { get; set; }
        public int AmountOfKeys { get; set; } = 0; //always set to 0 by default

        public int MaximumLives { get; set; } = 10; //always set to 10 by default

        /// Properties needed in the DarkForest
        public bool DestroyedTemple { get; set; } = false; //always set to false by default
        public bool TempleKeyFound { get; set; } = false; //always set to false by default
        public bool ReachedTempleKeyFight { get; set; } = false; //always set to false by default

        /// Properties needed in the Desert
        public char[,] Labyrinth { get; set; }
        public string LabyrinthPath { get; set; }

        public bool PassedCanyonGuardians { get; set; } = false; //always set to false by default
        public bool PassedLabyrinth { get; set; } = false; //always set to false by default
        public bool CanyonKeyFound { get; set; } = false; //always set to false by default

        /// Properties needed in the Endgame
        public bool CanRegenarateLives { get; set; } = true; //always set to true by default ,needed because the UndeadMage can stop the regeneration
        public int LastDealtDamage { get; set; } = 0; //always set to 0 by default, used to reflect the players damge in a figth against the ShieldWarrior
        public bool CanAttackUndeadKingWithBow { get; set; } = true; //in the beginning the player can attack with the bow until the UndeadKing has only 120 lives left
        public Enemy LastAttackedEnemy { get; set; } = null!; //always set to null by default, used to reflect the last attacked enemy in a fight against the ShieldWarrior

        public Player(string name)
        {
            Name = name;
            string labyrinthPath = "";
            Labyrinth = LabyrinthUtils.ReturnLabyrinth(ref labyrinthPath); //creates the labyrinth once, so it doesn't change through the game
            LabyrinthPath = labyrinthPath;
        }

        public void PerformAttack(Enemy enemy)
        {
            LastAttackedEnemy = enemy; //set the last attacked enemy to the current enemy, so the ShieldWarrior can reflect the attack

            if (enemy is ShieldWarrior)
            {
                if (enemy.ReflectsAttack)
                {
                    return;
                }
            }

            while(enemy is UndeadKing && CanAttackUndeadKingWithBow)
            {
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    {"Attack with bow", () => Attack.AttackUndeadKingWithBow(this, enemy as UndeadKing) },
                    {"Only attack with the swort", () => { CanAttackUndeadKingWithBow = false; } }
                }); 
            }
            if (!(enemy is UndeadKing) || !CanAttackUndeadKingWithBow)
            {
                Attack.ExecuteAttack(this, enemy);
            }
            
            if(enemy is CactusGolem)
            {
                if(this.CurrentVehicle != null)
                {
                    this.CurrentVehicle.Lives -= 50;
                    ConsoleUtils.ColorWriteLine($"You have lost 50 lives of your {this.CurrentVehicle.Name} due to the cactus spines.", "red");
                    if (this.CurrentVehicle.Lives <= 0)
                    {
                        Console.WriteLine();
                        ConsoleUtils.ColorWriteLine($"You have lost your {this.CurrentVehicle.Name}.", "red");
                        Console.WriteLine();
                        this.CurrentVehicle = null;
                    }
                }
                else
                {
                    this.Lives -= 1;

                    ConsoleUtils.ColorWriteLine($"You have lost 1 life due to the cactus spines.", "red");
                }
            }
        }

        public void PerformBowAttack(Enemy enemy) => Attack.ExecuteBowAttack(this, enemy);
    }
}

using ConsoleAdventureGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// The player class represents the player in the game.
    /// Furthermore, it is the reference point for all the properties that are needed in the game, because the player is the player is the only constant through the game.
    /// </summary>
    public class Player
    {
        /// Properties
        /// <summary>The name of the player.</summary>
        public string Name { get; set; }
        /// <summary>The amount of lives of the player</summary>
        public int Lives { get; set; } = 10; //always set to 10 by default
        /// <summary>The amoubt of coins of the player.</summary>
        public int Coins { get; set; } = 10; //always set to 10 by default
        /// <summary>The current weapon of the player.</summary>
        public Weapon? CurrentWeapon { get; set; }
        /// <summary>The flag that indicates bow ownership.</summary>
        public bool OwnsBow { get; set; } = false; //always set to false by default
        /// <summary>The amount of arrows that the player owns.</summary>
        public int ArrowAmount { get; set; } = 0; //always set to 0 by default
        /// <summary>The current vehicle of the player.</summary>
        public Vehicle? CurrentVehicle { get; set; }
        /// <summary>The amount of keys the player has collected.</summary>
        public int AmountOfKeys { get; set; } = 0; //always set to 0 by default

        /// <summary>The amount of lives that is maximum achievable through regeneration.</summary>
        public int MaximumLives { get; set; } = 10; //always set to 10 by default

        /// Properties needed in the DarkForest
        /// <summary>The flag that stores if the temple in the DarkForrest got destroyed.</summary>
        public bool DestroyedTemple { get; set; } = false; //always set to false by default
        /// <summary>The flag that stores if the player has the key in the temple.</summary>
        public bool TempleKeyFound { get; set; } = false; //always set to false by default
        /// <summary>The flag that stores if the player has reached the fight for the key of the temple.</summary>
        public bool ReachedTempleKeyFight { get; set; } = false; //always set to false by default

        /// Properties needed in the Desert
        /// <summary>the array that stores the structure of the lybyrinth in the Desert.</summary>
        public char[,] Labyrinth { get; set; }
        /// <summary>The string that stores the path through the labyrinth in the Desert.</summary>
        public string LabyrinthPath { get; set; }

        /// <summary>The flag that stores if the player has passed the guards of the Canoyn.</summary>
        public bool PassedCanyonGuardians { get; set; } = false; //always set to false by default
        /// <summary>The flag that stores if the player has passed the labyrinth in the Desert.</summary>
        public bool PassedLabyrinth { get; set; } = false; //always set to false by default
        /// <summary>The flag that stores if the player has found the key in the Canyon.</summary>
        public bool CanyonKeyFound { get; set; } = false; //always set to false by default

        /// Properties needed in the Endgame
        /// <summary>The flag that indicates if the player is able to regenarate.</summary>
        public bool CanRegenarateLives { get; set; } = true; //always set to true by default, needed because the UndeadMage can stop the regeneration
        /// <summary>The integer that stores the last damage which was dealt by the player.</summary>
        public int LastDealtDamage { get; set; } = 0; //always set to 0 by default, used to reflect the players damge in a figth against the ShieldWarrior
        /// <summary>The flag that indicates if the player is able to attack the UndeadKing with the bow.</summary>
        public bool CanAttackUndeadKingWithBow { get; set; } = true; //in the beginning the player can attack with the bow until the UndeadKing has only 120 lives left
        /// <summary>The last attacked enemy, used to reflect the attack of the ShieldWarrior.</summary>
        public Enemy LastAttackedEnemy { get; set; } = null!; //always set to null by default, used to reflect the last attacked enemy in a fight against the ShieldWarrior

        /// <summary>
        /// Constructor for the Player class. Creates a Labyrinth and the LabyrinthPath, which is used to navigate through the labyrinth in the Desert.
        /// </summary>
        /// <param name="name">The name of the player, used in the introduction.</param>
        public Player(string name)
        {
            Name = name;
            string labyrinthPath = "";
            Labyrinth = LabyrinthUtils.ReturnLabyrinth(ref labyrinthPath); //creates the labyrinth once, so it doesn't change through the game
            LabyrinthPath = labyrinthPath;
        }

        /// <summary>
        /// Uses the Attack class to perform an attack on an enemy. The ShieldWarrior, UndeadKing and CactusGolem have special characteristics that are handled in this method.
        /// </summary>
        /// <param name="enemy">The enemy that gets attacked.</param>
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

            // Check if the enemy is a CactusGolem, if so, the player loses lives or vehicle lives due to the cactus spines.
            if (enemy is CactusGolem)
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

        /// <summary>
        /// Uses the Attack class to perform a bow attack on an enemy.
        /// </summary>
        /// <param name="enemy">The enemy that gets attacked.</param>
        public void PerformBowAttack(Enemy enemy) => Attack.ExecuteBowAttack(this, enemy);
    }
}

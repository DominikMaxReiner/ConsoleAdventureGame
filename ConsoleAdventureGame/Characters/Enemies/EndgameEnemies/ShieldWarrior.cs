using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class ShieldWarrior : Enemy
    {
        public override string Name { get; } = "SHIELD WARRIOR";

        public override int Lives { get; set; } = 40;

        public override int Damage { get; } = 10;

        public override int CriticalHitChance { get; } = 3;

        // The Critical Damage is the same as the regular damage for Shield Warrior because his special attack is the relfection of the player's attack
        public override int CriticalDamage { get; } = 10;


        /// <summary>
        /// If the special attack is performed, the player's last dealt damage is reflected back to the player.
        /// </summary>
        /// <param name="player">The player whos damage gets returned.</param>
        public override void PerformAttack(Player player)
        {
            SetReflectsAttack(player); // sets the ReflectsAttack property to true or false

            if (ReflectsAttack)
            {
                DealDamage(player.LastDealtDamage, player); // if the special attack is performed, the player's last dealt damage is reflected back to the player
                Dialog.ShowMessage(Name, "I have reflected your attack with my shield!", "darkred");
            }
            else
            {
                base.PerformAttack(player); // if the special attack is not performed, the normal attack is performed
            }
        }

        // sets the ReflectsAttack property to true or false based on the player's last attacked enemy and a random chance
        private void SetReflectsAttack(Player player)
        {
            Random random = new Random();
            int attackType = random.Next(0, CriticalHitChance); // 2 is the special attack

            //also checks if the player has attacked the Shield Warrior before, so the special attack can only be performed if the Shiield Warrior was attacked by the player
            if (attackType == 2 && player.LastAttackedEnemy.Name == "SHIELD WARRIOR")
            {
                ReflectsAttack = true;
            }
            else
            {
                ReflectsAttack = false;
            }
        }
    }
}

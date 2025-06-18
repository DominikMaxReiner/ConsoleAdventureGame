using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class UndeadMage : Enemy
    {
        public override string Name { get; } = "UNDEAD MAGE";

        public override int Lives { get; set; } = 40;

        public override int Damage { get; } = 20;

        public override int CriticalHitChance { get; } = 4;

        // The Critical Damage is the same as the regular damage for Undead Mage because his special attack is a spell that weaks the player
        public override int CriticalDamage { get; } = 20;


        public override void PerformAttack(Player player)
        {
            Random random = new Random();
            int attackType = random.Next(0, CriticalHitChance); // 2 and 3 are the special attacks

            if (attackType == 3) // 25% chance to cast a spell that weakens the player
            {
                player.CurrentWeapon.Damage = player.CurrentWeapon.Damage / 2; // halve the player's weapon damage
                Dialog.ShowMessage(Name, "I have cast a spell that weakens you! Your weapon damage is halved! for this battle", "darkred");
            }
            else if (attackType == 2) // 25% chance to cast a spell that stops the regeneration of the player's lives
            {
                player.CanRegenarateLives = false; // stop the regeneration of the player's lives
                Dialog.ShowMessage(Name, "I have cast a spell that stops your regeneration! You cannot regenerate lives for this battle!", "darkred");
            }
            
            // A noraml attack is performed every time
            base.PerformAttack(player);
        }
    }
}

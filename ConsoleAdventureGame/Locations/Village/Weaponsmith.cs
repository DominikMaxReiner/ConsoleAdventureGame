using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// At the Weaponsmith, the player can buy weapons like a sword or a bow, and arrows if they own a bow.
    /// </summary>
    public class Weaponsmith : Location
    {
        public Weaponsmith(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "Welcome to the weaponsmith. Here you can buy weapons like a sword or a bow. Use //w to view your weapon.";

            Dialog.ShowMessage("Weaponsmith", introductionText, "cyan");
        }

        protected override void PerformAction(Player player)
        {
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"I want to buy a weapon" , () => BuyAWeapon(player)},
                {"Go back to the village" , () => new Village(player) }
            });
        }

        // The player can choose the weapon to buy.
        private void BuyAWeapon(Player player)
        {
            Dialog.ShowMessage("Weaponsmith", $"Which weapon would you like to buy? The sword costs {new Sword().Price} coins, and the bow costs {new Bow().Price} coins. You must pay 1 coin for each arrow.", "cyan");

            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"Buy the sword" , () => BuyAWeaponTransaction(player, new Sword())},
                {"Buy the bow" , () => BuyABow(player)},
                {"Buy arrows" , () => BuyAnArrowTransaction(player)},
                {"I don't want to buy a weapon" , () => new Weaponsmith(player)}
            });
        }

        // The purchase of a weapon is handled here, if the player has enough coins (using the InteractionUtils.BuySomething<Weapon>() method).
        private void BuyAWeaponTransaction(Player player, Weapon weapon)
        {
            Weapon currentWeapon = player.CurrentWeapon;
            InteractionUtils.BuySomething<Weapon>(player, weapon.Price, weapon, ref currentWeapon);
            player.CurrentWeapon = currentWeapon;
            _ = new Weaponsmith(player);
        }

        // The purchase of a bow is handled here, if the player has enough coins (using the InteractionUtils.BuySomething<bool>() method).
        private void BuyABow(Player player)
        {
            bool ownsBow = player.OwnsBow;
            InteractionUtils.BuySomething<bool>(player, new Bow().Price, true, ref ownsBow);
            player.OwnsBow = ownsBow;
            _ = new Weaponsmith(player);
        }

        // The purchase of arrows is handled here, if the player has enough coins and owns a bow (using the InteractionUtils.PerformTransaction() method).
        private void BuyAnArrowTransaction(Player player)
        {
            player.ArrowAmount += InteractionUtils.PerformTransaction(player, player.OwnsBow, "How many arrows would you like to buy? Each arrow costs 1 coin.", "You don't have a bow.");
            _ = new Weaponsmith(player);
        }
    }
}

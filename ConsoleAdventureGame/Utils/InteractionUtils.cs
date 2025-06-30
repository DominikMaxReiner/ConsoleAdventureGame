using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// This static class provides utility methods for player interactions involving purchases and transactions.
    /// </summary>
    public static class InteractionUtils
    {
        /// <summary>
        /// Handles the purchase of a single item by assigning the given value to a property if the player has enough coins.
        /// </summary>
        /// <typeparam name="T">The type of the item being purchased.</typeparam>
        /// <param name="player">The player making the purchase.</param>
        /// <param name="price">The price of the item.</param>
        /// <param name="value">The value to assign to the property.</param>
        /// <param name="property">A reference to the property to be updated.</param>
        static public void BuySomething<T>(Player player, int price, T value, ref T property)
        {
            if (player.Coins >= price)
            {
                player.Coins -= price;
                property = value;
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have enough coins.", "gray");
            }
        }

        /// <summary>
        /// Handles the purchase of a quantity-based resource by incrementing a referenced integer property.
        /// </summary>
        /// <param name="player">The player making the purchase.</param>
        /// <param name="price">The price per unit.</param>
        /// <param name="amount">The number of units to purchase.</param>
        /// <param name="property">A reference to the property that stores the quantity.</param>
        static public void BuySomething(Player player, int price, int amount, ref int property)
        {
            if (player.Coins >= price * amount)
            {
                player.Coins -= price * amount;
                property += amount;
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have enough coins.", "gray");
            }
        }

        /// <summary>
        /// Performs a simple transaction based on a success condition and returns the amount bought.
        /// </summary>
        /// <param name="player">The player performing the transaction.</param>
        /// <param name="isTransactionSuccess">Indicates whether the transaction is allowed.</param>
        /// <param name="successMessage">The message shown if the transaction succeeds.</param>
        /// <param name="errorMessage">The message shown if the transaction fails.</param>
        /// <returns>The amount purchased (0 if failed or nothing bought).</returns>
        static public int PerformTransaction(Player player, bool isTransactionSuccess, string successMessage, string errorMessage)
        {
            int intermediateVariable = 0;

            if (isTransactionSuccess)
            {
                ConsoleUtils.ColorWriteLine(successMessage, "cyan");

                int price = 1;
                int amount = InputUtils.GetPlayerInputNumber();

                BuySomething(player, price, amount, ref intermediateVariable);
            }
            else
            {
                ConsoleUtils.ColorWriteLine(errorMessage, "red");
            }
            Console.WriteLine("--------------------");
            Console.WriteLine();

            return intermediateVariable;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// This static class provides methods for displaying dialog messages in the console.
    /// </summary>
    public static class Dialog
    {
        /// <summary>
        /// Displays a message in the console with a specified sender name and color.
        /// </summary>
        /// <param name="messageSenderName">The name of the sender.</param>
        /// <param name="message">The displayed message.</param>
        /// <param name="color">The color of the text.</param>
        public static void ShowMessage(string messageSenderName, string message, string color)
        {
            ConsoleUtils.ColorWrite($"{messageSenderName}: ", "gray");
            ConsoleUtils.ColorWriteLine(message, color);
        }
    }
}

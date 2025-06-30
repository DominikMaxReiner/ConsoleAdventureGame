using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// Represents a text with an associated color.
    /// </summary>
    public class ColorTextObjects
    {
        /// <summary>The text that can be shown</summary>
        public string Text { get; set; }

        /// <summary>The color of the text</summary>
        public string Color { get; set; }

        public ColorTextObjects(string text, string color) // sets the Text and Color properties
        {
            Text = text;
            Color = color;
        }
    }
}
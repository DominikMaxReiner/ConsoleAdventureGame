using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class ColorTextObjects // TODO: check if this class is needed
    {
        public string Text { get; set; }
        public string Color { get; set; }

        public ColorTextObjects(string text, string color)
        {
            Text = text;
            Color = color;
        }
    }
}

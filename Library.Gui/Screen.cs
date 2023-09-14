using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Gui
{
    public abstract class Screen
    {
        public ConsoleColor dr = ConsoleColor.DarkRed;
        public ConsoleColor dg = ConsoleColor.DarkGreen;
        public ConsoleColor dy = ConsoleColor.DarkYellow;
        public ConsoleColor b = ConsoleColor.Black;
        public ConsoleColor dc = ConsoleColor.DarkCyan;
        public ConsoleColor y = ConsoleColor.Yellow;
        public ConsoleColor c = ConsoleColor.Cyan;

        public string? LoadDataJson { get; set; }


        #region Public Methods

        public virtual void Show()
        {
            Console.WriteLine("Screen");
        }

        #endregion // Public Methods
    }
}

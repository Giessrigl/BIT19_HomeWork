using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mine_Sweeper.Commands;
using Mine_Sweeper.ConsoleWatcher;
using Mine_Sweeper.Interfaces;
using Mine_Sweeper.Game_board_elements;
using Mine_Sweeper.KeyboardWatcher;

namespace Mine_Sweeper
{
    public struct Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="left">The horizontal position of an object.</param>
        /// <param name="top">The vertical position of an object.</param>
        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }

        /// <summary>
        /// Gets or sets the horizontal position of an element.
        /// </summary>
        /// <value>
        /// The horizontal position of an element.
        /// </value>
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the vertical position of an element.
        /// </summary>
        /// <value>
        /// The vertical position of an element.
        /// </value>
        public int Top
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represent types of tile in the game
    /// </summary>
    public enum TileType
    {
        /// <summary>
        /// A tile player cannot move through
        /// </summary>
        Wall,

        /// <summary>
        /// A tile player can move through
        /// </summary>
        Empty,

        /// <summary>
        /// An exit tile that allows player to win the game
        /// </summary>
        Exit
    }
}

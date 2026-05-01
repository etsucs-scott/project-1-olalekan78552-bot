using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represents a single tile in the maze, which may contain a type,
    /// an item, or a monster.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Gets the type of the tile.
        /// </summary>
        public TileType Type { get; private set; }

        /// <summary>
        /// Gets the item present on the tile, if any.
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// Gets the monster present on the tile, if any.
        /// </summary>
        public Monster Monster { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class
        /// with the specified tile type.
        /// </summary>
        /// <param name="type">The type of the tile.</param>
        public Tile(TileType type)
        {
            Type = type;
            Item = null;
            Monster = null;
        }

        /// <summary>
        /// Determines whether the tile can be walked on by the player.
        /// </summary>
        /// <returns>True if the tile is walkable; otherwise, false.</returns>
        public bool IsPositionWalkable()
        {
            return Type != TileType.Wall;
            
        }

        /// <summary>
        /// Determines whether the tile contains an item.
        /// </summary>
        /// <returns>True if an item is present; otherwise, false.</returns>
        public bool TileHasItem()
        {
            return Item != null;
        }

        /// <summary>
        /// Determines whether a monster is present on the tile.
        /// </summary>
        /// <returns>True if a monster is present; otherwise, false.</returns>
        public bool IsMonsterPresent()
        {
            return Monster != null;
        }

        /// <summary>
        /// Places a monster on the tile.
        /// </summary>
        /// <param name="monster">The monster to place on the tile.</param>
        public void PutMonster(Monster monster)
        {
            Monster = monster;
        }

        /// <summary>
        /// Places an item on the tile.
        /// </summary>
        /// <param name="item">The item to place on the tile.</param>
        public void PutItem(Item item)
        {
            Item = item;
        }

        /// <summary>
        /// Removes the item from the tile.
        /// </summary>
        public void ClearItem()
        {
            Item = null;
        }

        /// <summary>
        /// Removes the monster from the tile.
        /// </summary>
        public void ClearMonster()
        {
            Monster = null;
        }
    }
}

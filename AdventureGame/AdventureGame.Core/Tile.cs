using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    
    public class Tile
    {
        // declare tileType property
        public TileType Type { get; private set; }

        // declare and set Item property
        public Item Item { get; private set; }

        // declare and set monster property
        public Monster Monster { get; private set; }

        // tile constructor
        public Tile(TileType type)
        {
            Type = type;
            Item = null;
            Monster = null;
        }

        // check if position is empty
        public bool IsPositionWalakable()
        {
            return Type != TileType.Wall;
            
        }

        // check if tile has an item
        public bool TileHasItem()
        {
            return Item != null;
        }



        // check if monster is present on tile
        public bool IsMonsterPresent()
        {
            return Monster != null;
        }


        // set monster on tile
        public void PutMonster(Monster monster)
        {
            Monster = monster;
        }

        // set Item on Tile
        public void PutItem(Item item)
        {
            Item = item;
        }


        // clear item after player picks up
        public void ClearItem()
        {
            Item = null;
        }


        // clear monster if monster is dead
        public void ClearMonster()
        {
            Monster = null;
        }
    }
}

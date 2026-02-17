using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze
    {
        private Tile[,] grid;

        public int Cols { get; private set; }

        public  int Rows { get; private set; }

        public Position PlayerStart { get; private set; }

        public Position ExitTile { get; private set; }

        // maze constructor
        public Maze(int col, int row, Position playerStart)
        {
            // set col, row, and starting position
            Cols = col;
            Rows = row;
            PlayerStart = playerStart;

            // create a 2D array
            grid = new Tile[col, row];

            // fill array
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++ )
                {
                    grid[x, y] = new Tile(TileType.Empty);
                }
            }
            

        }

        // check if position is inside of grid
        public bool InMaze(Position i)
        {
            if (i.X < 0 || i.X >= Cols)
                return false;

            if (i.Y < 0 || i.Y >= Rows)
            {
                return false;
            }

            return true;

        }


        // return coordinate
        public Tile GetTile(Position i)
        {
            return grid[i.X, i.Y];
        }

        // generate grid maze content
        public void GenerateRandom(Random rand)
        {
             // clear grid before generating
             for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    grid[x, y] = new Tile(TileType.Empty);
                }
            }

            // set exit tile
            ExitTile = new Position(Cols - 2, Rows - 2);
            grid[ExitTile.X, ExitTile.Y] = new Tile(TileType.Exit);

            PlayerPath(PlayerStart, ExitTile);

            BorderWalls();
            SetMonster(rand, 4);
            SetPortion(rand, 3);
            SetWeapon(rand, 3);
        }


        public void PlayerPath(Position start, Position exit)
        {
            // set starting and ending coordinate
            int x = start.X;
            int y = start.Y;

            while (x != exit.X || y != exit.Y)
            {
                if (x < exit.X)
                {
                    x++;
                }
                else if (x > exit.Y)
                {
                    x--;
                }

                if (y < exit.Y)
                {
                    y++;
                }

                else if (y > exit.Y)
                {
                    y--;
                }

                if (!(x == exit.X && y == exit.Y))
                {
                    grid[x, y] = new Tile(TileType.Empty);
                }



            }

        }

        private void SetWeapon(Random rand, int count)
        {
            int placeWeapon = 0;

            while (placeWeapon < count)
            {
                int x = rand.Next(0, Cols);
                int y = rand.Next(0, Rows);

                if (grid[x, y].Type == TileType.Empty && !grid[x, y].TileHasItem() && !grid[x, y].IsMonsterPresent())
                {
                    int modifier = rand.Next(2, 6);
                    Weapon weapon = new Weapon("Weapon +" + modifier, "You picked a weapon", modifier);

                    grid[x, y].PutItem(weapon);
                    placeWeapon++;

                }
            }
        }

        private void BorderWalls()
        {
            // Top and bottom rows
            for (int x = 0; x < Cols; x++)
            {
                // Top row (y = 0)
                if (!(x == PlayerStart.X && 0 == PlayerStart.Y) &&
                    !(x == ExitTile.X && 0 == ExitTile.Y))
                {
                    grid[x, 0] = new Tile(TileType.Wall);
                }

                // Bottom row (y = Rows - 1)
                int bottomY = Rows - 1;
                if (!(x == PlayerStart.X && bottomY == PlayerStart.Y) &&
                    !(x == ExitTile.X && bottomY == ExitTile.Y))
                {
                    grid[x, bottomY] = new Tile(TileType.Wall);
                }
            }

            // Left and right columns
            for (int y = 0; y < Rows; y++)
            {
                // Left column (x = 0)
                if (!(0 == PlayerStart.X && y == PlayerStart.Y) &&
                    !(0 == ExitTile.X && y == ExitTile.Y))
                {
                    grid[0, y] = new Tile(TileType.Wall);
                }

                // Right column (x = Cols - 1)
                int rightX = Cols - 1;
                if (!(rightX == PlayerStart.X && y == PlayerStart.Y) &&
                    !(rightX == ExitTile.X && y == ExitTile.Y))
                {
                    grid[rightX, y] = new Tile(TileType.Wall);
                }
            }
        }

        // set monster randomly
        private void SetMonster(Random rand, int count)
        {
            int placemonster = 0;

            while (placemonster < count)
            {
                int x = rand.Next(0, Cols);
                int y = rand.Next(0, Rows);

                if (grid[x, y].Type == TileType.Empty && !grid[x, y].IsMonsterPresent())
                {
                    int modifier = rand.Next(2, 8);
                    Weapon playerWeapon = new Weapon("Weapon + " + modifier, "You have picked a new weapon ", modifier);
                    grid[x, y].PutMonster(new Monster("Evil", rand));
                    placemonster++;

                }
            }
        }

        // place potion randomly on a tile
        private void SetPortion(Random rand, int count)
        {
            int placePotion = 0;

            while (placePotion < count)
            {
                int x = rand.Next(0, Cols);
                int y = rand.Next(0, Rows);

                if (grid[x, y].Type == TileType.Empty && !grid[x, y].TileHasItem())
                {
                    Potion playerPotion = new Potion("Health Potion", "You health has increased");
                    grid[x, y].PutItem(playerPotion);
                    placePotion++;

                }
            }
        }




            
    }
}

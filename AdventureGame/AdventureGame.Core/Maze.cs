using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze
    {
        /// <summary>
        /// Represents the game maze containing tiles, player start position,
        /// exit location, and logic for generating and managing the grid.
        /// </summary>
        private Tile[,] grid;

        /// <summary>
        /// Gets the number of columns in the maze.
        /// </summary>
        public int Cols { get; private set; }

        /// <summary>
        /// Gets the number of rows in the maze.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Gets the starting position of the player.
        /// </summary>
        public Position PlayerStart { get; private set; }

        /// <summary>
        /// Gets the position of the exit tile.
        /// </summary>
        public Position ExitTile { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Maze"/> class
        /// and fills the grid with empty tiles.
        /// </summary>
        /// <param name="col">The number of columns in the maze.</param>
        /// <param name="row">The number of rows in the maze.</param>
        /// <param name="playerStart">The starting position of the player.</param>
        public Maze(int col, int row, Position playerStart)
        {
            Cols = col;
            Rows = row;
            PlayerStart = playerStart;
            grid = new Tile[col, row];

            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++ )
                {
                    grid[x, y] = new Tile(TileType.Empty);
                }
            }
        }

        /// <summary>
        /// Determines whether a given position is within the bounds of the maze.
        /// </summary>
        /// <param name="i">The position to check.</param>
        /// <returns>True if the position is inside the maze; otherwise, false.</returns>
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

        /// <summary>
        /// Gets the tile at the specified position in the maze.
        /// </summary>
        /// <param name="i">The position of the tile.</param>
        /// <returns>The tile at the given position.</returns>
        public Tile GetTile(Position i)
        {
            return grid[i.X, i.Y];
        }

        /// <summary>
        /// Generates a random maze layout including exit, path, walls,
        /// monsters, potions, and weapons.
        /// </summary>
        /// <param name="rand">The random number generator.</param>
        public void GenerateRandom(Random rand)
        {
             for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    grid[x, y] = new Tile(TileType.Empty);
                }
            }

            ExitTile = new Position(Cols - 2, Rows - 2);
            grid[ExitTile.X, ExitTile.Y] = new Tile(TileType.Exit);

            PlayerPath(PlayerStart, ExitTile);
            BorderWalls();
            SetMonster(rand, 4);
            SetPortion(rand, 3);
            SetWeapon(rand, 3);
        }

        /// <summary>
        /// Creates a path from the player's starting position to the exit tile.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="exit">The exit position.</param>
        public void PlayerPath(Position start, Position exit)
        {
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

        /// <summary>
        /// Places boundary walls around the edges of the maze,
        /// preserving the player start and exit positions.
        /// </summary>
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

        /// <summary>
        /// Randomly places weapons in empty tiles within the maze.
        /// </summary>
        /// <param name="rand">The random number generator.</param>
        /// <param name="count">The number of weapons to place.</param>
        private void BorderWalls()
        {
            for (int x = 0; x < Cols; x++)
            {
                if (!(x == PlayerStart.X && 0 == PlayerStart.Y) &&
                    !(x == ExitTile.X && 0 == ExitTile.Y))
                {
                    grid[x, 0] = new Tile(TileType.Wall);
                }

                int bottomY = Rows - 1;
                if (!(x == PlayerStart.X && bottomY == PlayerStart.Y) &&
                    !(x == ExitTile.X && bottomY == ExitTile.Y))
                {
                    grid[x, bottomY] = new Tile(TileType.Wall);
                }
            }

            for (int y = 0; y < Rows; y++)
            {
                if (!(0 == PlayerStart.X && y == PlayerStart.Y) &&
                    !(0 == ExitTile.X && y == ExitTile.Y))
                {
                    grid[0, y] = new Tile(TileType.Wall);
                }

                int rightX = Cols - 1;
                if (!(rightX == PlayerStart.X && y == PlayerStart.Y) &&
                    !(rightX == ExitTile.X && y == ExitTile.Y))
                {
                    grid[rightX, y] = new Tile(TileType.Wall);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rand">Random number generator</param>
        /// <param name="count">The number of monsters to place</param>
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

        /// <summary>
        /// places portions randomly on the board
        /// </summary>
        /// <param name="rand">The random number generator</param>
        /// <param name="count">The amount of portions to place</param>
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

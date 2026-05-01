using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Core;
class Program
{
    /// <summary>
    /// Starts the adventure game, creates the player, maze, and game engine,
    /// then runs the main game loop until the player wins or loses.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the program.</param>
    static void Main(string[] args)
    {
        Random rand = new Random();

        Player player = new Player("Hero", new Position(1, 1));

        Maze maze = new Maze(10, 10, player.Position);
        maze.GenerateRandom(rand);

        GameEngine engine = new GameEngine(maze, player);

        while (!engine.IsGameOver)
        {
            DrawGame(engine);
            HandleInput(engine);
        }
        if (engine.PlayerWon)
            Console.WriteLine("\nYou finished the game");
        else
            Console.WriteLine("You died, Game Over!");

        Console.ReadKey();
    }

    /// <summary>
    /// Reads the player's keyboard input and moves the player in the selected direction.
    /// </summary>
    /// <param name="engine">The game engine used to process player movement.</param>
    static void HandleInput(GameEngine engine)
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        Direction? direction = null;

        if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
            direction = Direction.Up;
        else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
            direction = Direction.Down;
        else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
            direction = Direction.Left;
        else if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
            direction = Direction.Right;

        if (direction.HasValue)
            engine.TryMove(direction.Value);

    }

    /// <summary>
    /// Draws the current maze, player, monsters, items, health, weapon bonus,
    /// and latest game message to the console.
    /// </summary>
    /// <param name="engine">The game engine containing the current game state.</param>
    static void DrawGame(GameEngine engine)
    {
        Console.Clear();

        Maze maze = engine.Maze;

        Player player = engine.Player;

        for (int y = 0; y < maze.Rows; y++)
        {
            for (int x = 0; x < maze.Cols; x++)
            {
                Position coord = new Position(x, y);
                Tile tile = maze.GetTile(coord);

                if (player.Position.X == x && player.Position.Y == y)
                {
                    Console.Write("@ ");
                }

                else if (tile.Type == TileType.Wall)
                {
                    Console.Write("# ");
                }
                else if (tile.Type == TileType.Exit)
                {
                    Console.Write("E ");
                }

                else if (tile.IsMonsterPresent())
                {
                    Console.Write("M ");
                }

                else if (tile.TileHasItem() && tile.Item is Weapon)
                {
                    Console.Write("W ");
                }

                else if (tile.TileHasItem() && tile.Item is Potion)
                {
                    Console.Write("P ");
                }

                else
                {
                    Console.Write(". ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"HP: {player.Health}/{player.MaxHealth}");
        Console.WriteLine($"Max Weapon Bonus: {player.Inventory.HighestWeapon}");
        Console.WriteLine(engine.LastMessage);

    }
}
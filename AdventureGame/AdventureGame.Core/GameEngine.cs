using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class GameEngine
    {
        public Maze Maze { get; }
        public Player Player { get; }
        public bool IsGameOver { get; private set; }
        public bool PlayerWon { get; private set; }
        public string LastMessage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class
        /// with the specified maze and player.
        /// </summary>
        /// <param name="maze">The maze used for the game.</param>
        /// <param name="player">The player participating in the game.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the maze or player is null.
        /// </exception>
        public GameEngine(Maze maze, Player player)
        {
            Maze = maze ?? throw new ArgumentNullException(nameof(maze));
            Player = player ?? throw new ArgumentNullException(nameof(player));
            IsGameOver = false;
            PlayerWon = false;
            LastMessage = " ";
        }

        /// <summary>
        /// Attempts to move the player in the specified direction.
        /// Validates movement boundaries and resolves tile interactions.
        /// </summary>
        /// <param name="direction">The direction the player wants to move.</param>
        public void TryMove(Direction direction)
        {
            if (IsGameOver)
            {
                LastMessage = "Game Over! Thank you for playing";
                return;
            }

            Position current = Player.Position;
            Position next = GetNextPosition(current, direction);

            if (!Maze.InMaze(next))
            {
                LastMessage = "You can't go that way";
                return;
            }

            Tile nextTile = Maze.GetTile(next);

            if (!nextTile.IsPositionWalkable())
            {
                LastMessage = "You hit a wall";
                return;
            }

            Player.MoveTo(next);
            ResolveTile(nextTile);
        }

        /// <summary>
        /// Calculates the next position based on the current position
        /// and the given movement direction.
        /// </summary>
        /// <param name="current">The current player position.</param>
        /// <param name="direction">The direction of movement.</param>
        /// <returns>The new calculated position.</returns>
        private Position GetNextPosition(Position current, Direction direction)
        {
            int x = current.X;
            int y = current.Y;

            if (direction == Direction.Up)
            {
                y--;
            }

            else if (direction == Direction.Down)
            {
                y++;
            }

            else if (direction == Direction.Left)
            {
                x--;
            }
            else if (direction == Direction.Right)
            {
                x++;
            }

                return new Position(x, y);
        }

        /// <summary>
        /// Resolves interactions when the player enters a tile,
        /// including exit detection, combat, and item pickup.
        /// </summary>
        /// <param name="tile">The tile the player has moved onto.</param>
        private void ResolveTile(Tile tile)
        {
            if (tile.Type == TileType.Exit)
            {
                IsGameOver = true;
                PlayerWon = true;
                LastMessage = "Congratulations, You found the exit and you have won!";
                return;
            }

            if (tile.IsMonsterPresent())
            {
                Monster monster = tile.Monster;

                string battleMsg = FightMonster(monster);

                if (!Player.IsAlive)
                {
                    IsGameOver = true;
                    PlayerWon = false;
                    LastMessage = battleMsg;
                    return;
                }

                if (!monster.IsAlive)
                {
                    tile.ClearMonster();
                }
                LastMessage = battleMsg;
                return;
            }

            if(tile.TileHasItem())
            {
                Item item = tile.Item;
                if (item is Weapon weapon)
                {
                    Player.Inventory.AddWeapon(weapon);
                    tile.ClearItem();
                    LastMessage = weapon.PickupMessage;
                    return;
                }

                if (item is Potion potion)
                {
                    Player.Heal(potion.HealPotion);
                    tile.ClearItem();
                    LastMessage = potion.PickupMessage;
                    return;
                }

                tile.ClearItem();
                LastMessage = "You picked an item";
                return;
            }   
        }

        /// <summary>
        /// Handles combat between the player and a monster.
        /// Continues until either the player or the monster is defeated.
        /// </summary>
        /// <param name="monster">The monster being fought.</param>
        /// <returns>
        /// A string describing the sequence of battle events and outcome.
        /// </returns>
        private string FightMonster(Monster monster)
        {
            string battleMessage = "";
            
            while (Player.IsAlive && monster.IsAlive)
            {
                int playerDamage = Player.Attack(monster);
                battleMessage += $"You hit {monster.Name} for {playerDamage} damage.\n"; 

                if (!monster.IsAlive)
                {
                    battleMessage += $"Monster has been defeated";
                    break;   
                }

                int monsterDamage = monster.Attack(Player);
                battleMessage += $"{monster.Name} hits you for {playerDamage} damage.\n";

                if (!Player.IsAlive)
                {
                    battleMessage += $"You've been defeated";
                    break;  
                }    
            }
            return battleMessage;
        }
    }
}

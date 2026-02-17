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

        // game egine constructor
        public GameEngine(Maze maze, Player player)
        {
            //set maze to maze if not null
            Maze = maze ?? throw new ArgumentNullException(nameof(maze));
            Player = player ?? throw new ArgumentNullException(nameof(player));

            IsGameOver = false;
            PlayerWon = false;
            LastMessage = " ";
        }

        public void TryMove(Direction direction)
        {
            if (IsGameOver)
            {
                LastMessage = "Game Over! Thank you for playing";
                return;
            }

            Position current = Player.Position;
            Position next = GetNextPosition(current, direction);

            // check off grid
            if (!Maze.InMaze(next))
            {
                LastMessage = "You can't go that way";
                return;
            }

            Tile nextTile = Maze.GetTile(next);

            // check wall

            if (!nextTile.IsPositionWalakable())
            {
                LastMessage = "You hit a wall";
                return;
            }

            // move player
            Player.MoveTo(next);
            ResolveTile(nextTile);

        }

        


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

        private void ResolveTile(Tile tile)
        {
            // exit game
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

                // if player dead
                if (!Player.IsAlive)
                {
                    IsGameOver = true;
                    PlayerWon = false;
                    LastMessage = battleMsg;
                    return;
                }

                //Monster was defeated
                if (!monster.IsAlive)
                {
                    tile.ClearMonster();
                }
                LastMessage = battleMsg;
                return;
            }


            // pick up Items
            if(tile.TileHasItem())
            {
                Item item = tile.Item;

                // add weapon to inventory
                if (item is Weapon weapon)
                {
                    Player.Inventory.AddWeapon(weapon);
                    tile.ClearItem();
                    LastMessage = weapon.PickupMessage;
                    return;
                }

                // Pick potion to increase health
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

        private string FightMonster(Monster monster)
        {
            
            // continue the loop as long as player and monster are alive
            while (Player.IsAlive && monster.IsAlive)
            {
                int playerDamage = Player.Attack(monster);

                // if monster is dead
                if (!monster.IsAlive)
                {
                    return $"You hit the {monster.Name} for {playerDamage}. {monster.Name} has been defeated";
                   
                }

                int monsterDamage = monster.Attack(Player);

                // if monster kills player
                if (!Player.IsAlive)
                {
                    return $"You hit the {monster.Name} for {playerDamage} damage";
                     
                }

                return $"You hit {monster.Name} for {playerDamage}. {monster.Name} hit for {monsterDamage}.\n";
            }

            return "";
        }

    }
}

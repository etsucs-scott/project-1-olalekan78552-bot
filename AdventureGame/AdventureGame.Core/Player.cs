using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represents the player character in the game, including health,
    /// position, inventory, and combat abilities.
    /// </summary>
    public class Player : ICharacter
    {
        private int _health;
        private readonly int _maxHealth = 150;
        private const int BaseDamage = 10;

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///  Gets players current position in maze
        /// </summary>
        public Position Position { get; private set; }


        /// <summary>
        /// Gets players inventory
        /// </summary>
        public Inventory Inventory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class
        /// with a name and starting position.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="startPosition">The starting position of the player.</param>
        public Player(string name, Position startPosition)
        {
            Name = name;
            _health = 100;
            Position = startPosition;

            Inventory = new Inventory();
        }

        /// <summary>
        /// Gets the current health of the player.
        /// </summary>
        public int Health
        {
            get
            {
                return _health;
            }
        }

        /// <summary>
        /// Gets the maximum health of the player.
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
        }

        /// <summary>
        ///  return a value indicating if the monster is still alive
        /// </summary>
        public bool IsAlive
        {
            get
            {
                return _health > 0;
            }
        }

        /// <summary>
        /// Attacks a target character using base damage and weapon bonus.
        /// </summary>
        /// <param name="target">The character being attacked.</param>
        /// <returns>The total damage dealt to the target.</returns>
        public int Attack(ICharacter target)
        {
            int damage;

            damage = BaseDamage + Inventory.HighestWeapon;

            // apply damage to target
            target.TakeDamage(damage);

            return damage;
        }

        /// <summary>
        /// deduct damage from characters health
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            if (amount <= 0)
            {
                return;
            }
            _health = _health - amount;

            if (_health < 0)
            {
                _health = 0;
            }
        }

        /// <summary>
        /// restore players health when player picks up portions
        /// portion will not exceed max health
        /// </summary>
        /// <param name="potion"></param>
        public void Heal(int potion)
        {
            if (potion <= 0)
                return;

            _health = _health + potion;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }

        /// <summary>
        /// move player to a new position in the maze
        /// </summary>
        /// <param name="newPosition"></param>
        public void MoveTo(Position newPosition)
        {
            Position = newPosition;
        }
    }
}

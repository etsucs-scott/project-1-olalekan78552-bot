using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        private int _health;
        private readonly int _maxHealth = 150;
        private const int BaseDamage = 10;
        public string Name { get; }

        public Position Position { get; private set; }

        public Inventory Inventory { get; }

        public Player(string name, Position startPosition)
        {
            Name = name;
            _health = 100;
            Position = startPosition;

            Inventory = new Inventory();
        }


        // get and return health
        public int Health
        {
            get
            {
                return _health;
            }
        }

        // get and return maxHealth
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
        }

        // get and return IsALive
        // if health is greater than 0. then player/ monster is still alive
        public bool IsAlive
        {
            get
            {
                return _health > 0;
            }
        }

        public int Attack(ICharacter target)
        {
            int damage;

            // add max weapon to base damage
            damage = BaseDamage + Inventory.HighestWeapon;

            // apply damage to target
            target.TakeDamage(damage);

            return damage;
        }


        public void TakeDamage(int amount)
        {
            // if damage is less than or equal zero, do nothing
            if (amount <= 0)
            {
                return;
            }

            // deduct damage from current health
            _health = _health - amount;

            // if health is less than 0, set health equal to zero
            if (_health < 0)
            {
                _health = 0;
            }


        }

        public void Heal(int potion)
        {
            // if potion is less than or equal to zero
            if (potion <= 0)
                return;

            // add potion to health
            _health = _health + potion;

            // if health is greater than max health, set health to max health
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }

        public void MoveTo(Position newPosition)
        {
            Position = newPosition;
        }
    }
}

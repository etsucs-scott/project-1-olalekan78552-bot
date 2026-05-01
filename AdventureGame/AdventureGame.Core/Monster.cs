using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represents an enemy character in the game that can attack the player
    /// and receive damage during combat.
    /// </summary>
    public class Monster : ICharacter
    {
        private int _health;
        private readonly int _maxHealth;        
        private const int BaseDamage = 10;

        /// <summary>
        /// gets the monsters name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// return the amount of health the monster has left
        /// </summary>
        public int Health
        {
            get
            {
                return _health;
            }
        }

        /// <summary>
        /// return max health monster can have
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
        /// create an instance of the <see cref="Monster"/> 
        /// </summary>                 
        /// <param name="name">The name of the monster</param>
        /// <param name="rand">A random number generator to generate monsters health</param>
        public Monster(string name, Random rand)
        {
            Name = name;
            _maxHealth = rand.Next(30, 51);
            _health = _maxHealth;

        }

        /// <summary>
        /// Attack a target character and apply damage
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Attack(ICharacter target)
        {
            int damage = BaseDamage;
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
    }
}

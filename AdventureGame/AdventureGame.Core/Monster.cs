using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    
    public class Monster : ICharacter
    {
        private int _health;
        private readonly int _maxHealth;
        
        private const int BaseDamage = 10;

        public string Name { get; }
        public int Health
        {
            get
            {
                return _health;
            }
        }

        public int MaxHealth 
        {   
            get
            {
                return _maxHealth;
            }
        }

        public bool IsAlive
        {
            get
            {   // return alive if health is greater than 0
                return _health > 0;
            }
        }


        public Monster(string name, Random rand)
        {
            Name = name;
            _maxHealth = rand.Next(30, 51);
            _health = _maxHealth;

        }







        public int Attack(ICharacter target)
        {
            int damage = BaseDamage;

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
    }
}

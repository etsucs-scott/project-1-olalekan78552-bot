using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int AttackModifier { get; set; }
        public Weapon(string name, string pickupMessage, int attackModifier) : base(name, pickupMessage)
        {
            AttackModifier = attackModifier;
        }

        

        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int HealPotion { get; } = 20;

        public Potion(string name, string pickupMessage) : base(name, pickupMessage)
        {
        }
    }
}

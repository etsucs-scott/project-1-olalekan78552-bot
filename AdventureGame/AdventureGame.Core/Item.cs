using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public abstract class Item
    {
        public string Name { get; }
        public string PickupMessage { get; }

        protected Item(string name, string pickupMessage)
        {
            Name = name;
            PickupMessage = pickupMessage;
        }
            
    }
}

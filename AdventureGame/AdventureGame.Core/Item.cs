using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represents a base item in the game that can be collected by the player.
    /// Provides common properties such as name and pickup message for all item types.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// Gets the name of the item.
        /// </summary>       
        public string Name { get; }

        /// <summary>
        /// Gets the message displayed when the item is picked up.
        /// </summary>
        public string PickupMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="pickupMessage">The message displayed when the item is picked up.</param>
        protected Item(string name, string pickupMessage)
        {
            Name = name;
            PickupMessage = pickupMessage;
        }
            
    }
}

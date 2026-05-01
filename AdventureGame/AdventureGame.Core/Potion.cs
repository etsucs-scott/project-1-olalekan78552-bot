using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represents a health potion item that restores the player's health when used.
    /// </summary>
    public class Potion : Item
    {
        /// <summary>
        /// Gets the amount of health restored by the potion.
        /// </summary>
        public int HealPotion { get; } = 20;


        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// </summary>
        /// <param name="name">The name of the potion.</param>
        /// <param name="pickupMessage">The message displayed when the potion is picked up.</param>
        public Potion(string name, string pickupMessage) : base(name, pickupMessage)
        {
        }
    }
}

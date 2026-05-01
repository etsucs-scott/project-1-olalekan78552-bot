using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Represents a weapon item that increases the player's attack power.
    /// </summary>
    public class Weapon : Item
    {
        /// <summary>
        /// get the attack modifier provided by the weapon
        /// </summary>
        public int AttackModifier { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="pickupMessage">The message displayed when the weapon is picked up.</param>
        /// <param name="attackModifier">The attack bonus provided by the weapon.</param>
        public Weapon(string name, string pickupMessage, int attackModifier) : base(name, pickupMessage)
        {
            AttackModifier = attackModifier;
        } 
    }
}

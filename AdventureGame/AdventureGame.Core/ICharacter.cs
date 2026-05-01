using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Defines the basic behavior and properties for all characters in the game,
    /// including players and monsters.
    /// </summary>
    public interface ICharacter
    { 
        /// <summary>
        /// Gets the name of the character.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the current health of the character.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Gets the maximum health of the character.
        /// </summary>
        int MaxHealth { get; }

        /// <summary>
        ///  get a value to check if character is alive
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Combat attack on a character
        /// </summary>
        /// <param name="target">The character being attacked</param>
        /// <returns>The amount of damage dealt to the character</returns>
        public int Attack(ICharacter target);

        /// <summary>
        /// Applies damage to the character, reducing its health.
        /// </summary>
        /// <param name="amount">The amount of damage to apply.</param>
        public void TakeDamage(int amount);
    }
}

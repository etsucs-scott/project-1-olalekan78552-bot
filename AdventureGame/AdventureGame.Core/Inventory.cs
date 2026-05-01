using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    ///  Represent player's inventory, stores pickup weapon and provide access to       
    ///  strongest weapon
    /// </summary>
    public class Inventory
    {
        private readonly List<Weapon> _weapons = new List<Weapon>();

        /// <summary>
        /// return a list of weapons in player inventory
        /// </summary>
        public IReadOnlyList<Weapon> Weapons
        {
            get
            {
                return _weapons;
            }
        }

        /// <summary>
        /// Gets the highest attack modifier among all weapon and returns 0 if weapon is 
        /// present 
        /// </summary>
        public int HighestWeapon
        {
            get
            {
                if (_weapons.Count == 0)
                    return 0;

                return _weapons.Max(w => w.AttackModifier);
            }
        }

        /// <summary>
        /// Add a weapon to the inventory
        /// </summary>
        public void AddWeapon(Weapon weapon)
        {
            if (weapon == null)
            {
                return;
            }
            _weapons.Add(weapon);
        }
    }
}

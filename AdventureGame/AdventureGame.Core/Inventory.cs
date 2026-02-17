using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Inventory
    {
        // store weapon object inside a list

        private readonly List<Weapon> _weapons = new List<Weapon>();

        public IReadOnlyList<Weapon> Weapons
        {
            get
            {
                return _weapons;
            }
        }

        public int HighestWeapon
        {
            get
            {
                if (_weapons.Count == 0)
                    return 0;

                return _weapons.Max(w => w.AttackModifier);
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
        }
    }
}

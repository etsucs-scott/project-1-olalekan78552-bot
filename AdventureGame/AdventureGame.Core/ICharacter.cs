using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public interface ICharacter
    {
         string Name { get; }

        int Health { get; }

        int MaxHealth { get; }

        bool IsAlive { get; }

        public int Attack(ICharacter target);

        public void TakeDamage(int amount);
    }
}

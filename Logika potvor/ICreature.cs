using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    interface ICreature
    {
        void Move();

        int ReciveDamage(int damage);

        void Shoot();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    interface ICreature
    {
        int ReciveDamage(int damage);
        Boolean isDead();

        Status getDying();
        Status getShooting();
        Status getMoovnig();
    }
}

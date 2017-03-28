using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6.Logika_vezi
{
    interface ITower
    {
        void shoot();
        int receiveDamage(int dmg);
        bool canBePlaced(int x, int y);
    }
}

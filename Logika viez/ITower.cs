using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
   public interface ITower
    {
        void shoot();
        int receiveDamage(int dmg);
        bool canBePlaced(int x, int y);
        Node findTarget(Node Position);
        Boolean isDead();
    }
}

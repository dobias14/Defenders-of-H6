using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
   public interface ITower
    {
        int receiveDamage(int dmg);
        int getDamage();
        bool canBePlaced(int x, int y);
        Node getPosition();
        Boolean isDead();
        Status getDying();
        Status getAiming();
    }
}

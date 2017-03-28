using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6.Logika_vezi
{
    class BasicTower: ThinkingObject, ITower
    {
        private int damage;
        private int hp;
        private int attackRage;
        private bool isShooting;
        private int size;
        private int X, Y;


        public override void action()
        {
            throw new NotImplementedException();
        }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public int receiveDamage(int dmg)
        {
            throw new NotImplementedException();
        }

        public void shoot()
        {
            throw new NotImplementedException();
        }

        public bool canBePlaced(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}

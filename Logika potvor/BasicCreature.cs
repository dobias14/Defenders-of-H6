using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    class BasicCreature : ThinkingObject, ICreature
    {

        private int damage;
        private int hp;
        
        public override void action()
        {
            throw new NotImplementedException();
            
        }

        public override void draw()
        {
            throw new NotImplementedException();
        }
        

        public void Move()
        {
            throw new NotImplementedException();
        }

        public int ReciveDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
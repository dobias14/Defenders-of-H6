using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    class Mooving : Status
    {
        private ICreature creature;

        public Mooving(ICreature creature)
        {
            this.creature = creature;
        }
        
        public Status changeStatus()
        {
            if (this.creature.isDead())
            {
                return this.creature.getDiying();
            }
            //change to Shooting is missing
            return null;
        }

        public void onEnd()
        {
            throw new NotImplementedException();
        }

        public void onStart()
        {
            throw new NotImplementedException();
        }

        public void prepare()
        {
            throw new NotImplementedException();
        }
    }
}

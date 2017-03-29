using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesV2
{
    class Dying : Status
    {
        private ICreature creature;

        public Dying(ICreature creature)
        {
            this.creature = creature;
        }

        public Status changeStatus()
        {
            return null;
        }

        public void onEnd()
        {
            //do nothing
        }

        public void onStart()
        {
            //do nothing
        }

        public void prepare()
        {
            //do nothing
        }
    }
}

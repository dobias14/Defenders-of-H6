using System;

namespace DefendersOfH6
{
    public class Dying : Status
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

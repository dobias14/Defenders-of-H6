using System;

namespace DefendersOfH6
{
    public class Sleeping : Status
    {
        private ITower tower;

        public Sleeping(ITower tower)
        {
            this.tower = tower;
        }

        public Status changeStatus()
        {
            if (this.tower.isDead())
            {
                return this.tower.getDying();
            }
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

using System;

namespace DefendersOfH6
{
    public class DyingTower : Status
    {
        private ITower tower;

        public DyingTower(ITower tower)
        {
            this.tower = tower;
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

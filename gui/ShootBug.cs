using System;

namespace DefendersOfH6
{
    public class ShootBug : Status
    {
        private ITower tower;
        private Graph graph;

        public ShootBug(ITower tower, Graph graph)
        {
            this.tower = tower;
            this.graph = graph;
        }

        public Status changeStatus()
        {
            throw new NotImplementedException();
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

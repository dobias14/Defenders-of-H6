using System;

namespace DefendersOfH6
{
    public class Shooting : Status
    {
        private ICreature creature;
        private Graph graph;

        public Shooting(ICreature creature, Graph graph)
        {
            this.creature = creature;
            this.graph = graph;
        }

        public Status changeStatus()
        {
            if (this.creature.isDead())
            {
                return this.creature.getDying();
            }
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

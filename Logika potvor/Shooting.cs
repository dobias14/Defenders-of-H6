using System;

namespace DefendersOfH6
{
    public class Shooting : Status
    {
        private ICreature creature;
        private int damage;
        public int Damage { get { return this.damage; } }

        public Shooting(ICreature creature)
        {
            this.creature = creature;
            this.damage = 0;
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
        }

        public void onStart()
        {
            int damage = ((BasicCreature)creature).Damage;
        }

        public void prepare()
        {
            int damage = ((BasicCreature)creature).Damage;
        }

    }
}

using System;

namespace DefendersOfH6
{
    public class Shooting : Status
    {
        private ICreature creature;
        private World world;
        private int damage;
        public int Damage { get { return damage; } }

        public Shooting(ICreature creature, World world)
        {
            this.creature = creature;
            this.damage = 0;
            this.world = world;
        }

        public Status changeStatus()
        {
            if (this.creature.isDead())
            {
                return creature.getDying();
            }
            return null;
        }

        public void onEnd()
        {
        }

        public void onStart()
        {
            damage = ((BasicCreature)creature).Damage;
        }

        public void prepare()
        {
            world.doDamegeToH6Server(damage);
        }

    }
}

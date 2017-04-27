using System;

namespace DefendersOfH6
{
    public interface ICreature
    {
        int ReciveDamage(int damage);
        Boolean isDead();

        Node getPosition();

        Status getDying();
        Status getShooting();
        Status getMoovnig();
    }
}

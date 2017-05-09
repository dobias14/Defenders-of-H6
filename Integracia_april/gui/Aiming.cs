using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    public class Aiming : Status
    {

        private ICreature target;
        public ICreature Target { get { return this.target; } }


        private List<ThinkingObject> creatures;
        private Graph graph;
        private ITower tower;

        public Aiming(List<ThinkingObject> creatures, Graph graph, ITower tower)
        {
            this.creatures = creatures;
            this.graph = graph;
            this.tower = tower;
           
        }

        public Status changeStatus()
        {
            if (tower.isDead())
            {
                return tower.getDying();
            }
            else {
                return null;
            }//return tower.getAiming();

        }

        public void onEnd()
        {
            Console.WriteLine("som tu");
            if (target.isDead())
            {
                findTarget();
            }
        }

        public void onStart()
        {
            Console.WriteLine("som zacal");
            findTarget();
        }

        public void prepare()
        {
            if (tower.isDead())
            {
                Console.WriteLine("zomrela veza");
                changeStatus();
            }

            if (target.isDead())
            {
                Console.WriteLine("som zabil");
                changeStatus();
                findTarget();
            }
            else
            {
                Console.WriteLine("utocim");
            }
        }

        public void findTarget()
        {
            int distanceToTower = -9999;
            for (int i = 0; i < creatures.Count(); i++)
            {
                if (creatures[i].GetType() == typeof(BasicCreature))
                {
                    BasicCreature c = (BasicCreature) creatures[i];
                    if(c.getPosition().getX() + c.getPosition().getY() > distanceToTower && !c.isDead())
                    {
                        distanceToTower = c.getPosition().getX() + c.getPosition().getY();
                        target = c;
                    }
                }
            }
        }
    }
}

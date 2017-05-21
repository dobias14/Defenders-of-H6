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

        private List<ICreature> allcreatures;
        public List<ICreature> Allcreatures { get { return this.allcreatures; } }

        private List<ThinkingObject> creatures;
        private Graph graph;
        private ITower tower;

        public Aiming(List<ThinkingObject> creatures, Graph graph, ITower tower)
        {
            allcreatures = new List<ICreature>();
            this.creatures = creatures;
            this.graph = graph;
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
            Console.WriteLine("som tu");
            if (target.isDead())
            {
                findTarget();
            }
        }

        public void onStart()
        {
            Console.WriteLine("som zacal");
            if(tower.GetType() == typeof(BasicTower))
            {
                findTarget();
            }
            if (tower.GetType() == typeof(MultiTargetTower))
            {
                getTargets();
            }
        }

        public void prepare()
        {
            if (tower.GetType() == typeof(BasicTower))
            {
                singleTowerAction();
            }
            if (tower.GetType() == typeof(MultiTargetTower))
            {
                MultiTowerAction();
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

        public void getTargets()
        {
            for (int i = 0; i < creatures.Count(); i++)
            {
                if (creatures[i].GetType() == typeof(BasicCreature))
                {
                    BasicCreature c = (BasicCreature)creatures[i];
                    if (!c.isDead() && !allcreatures.Contains(c) && allcreatures.Count()<=5)
                    {
                        allcreatures.Add(c);
                    }
                }

            }
        }

        public void singleTowerAction()
        {
            if (target == null || (target != null && target.isDead()))
            {
                findTarget();
            }
            else
            {
                Console.WriteLine("utocim");
            }
        }

        public void MultiTowerAction()
        {
            List<BasicCreature> toRemove = new List<BasicCreature>();
            if (allcreatures.Count() <= 0)
            {
                getTargets();
            }
            foreach (BasicCreature c in allcreatures)
            {
                if (c.isDead())
                {
                    toRemove.Add(c);
                }
                else
                {
                    Console.WriteLine("utoci multi veza");
                }
            }
            if (toRemove.Count() > 0)
            {
          
                foreach(BasicCreature bc in toRemove)
                {
                    allcreatures.Remove(bc);
                }
              
                getTargets();
            }
            
        }

    }

}

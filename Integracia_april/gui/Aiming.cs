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

   
        private List<ICreature> creatures;
        private Graph graph;
        private ITower tower;

        public Aiming(List<ICreature> creatures, Graph graph, ITower tower)
        {
            this.creatures = creatures;
            this.graph = graph;
            this.tower = tower;
            //findTarget();
           
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
            if (target.isDead())
            {
                findTarget();
            }
        }

        public void onStart()
        {
            findTarget();
        }

        public void prepare()
        {
        }

        public void findTarget()
        {
            int max = 0;
            for (int i = 0; i < creatures.Count(); i++)
            {
                if (max <= creatures[i].getPosition().getX() + creatures[i].getPosition().getY() && creatures[i].isDead() == false)
                {
                    max = creatures[i].getPosition().getX() + creatures[i].getPosition().getY();
                    target = creatures[i];
                }
            }
        }
    }
}

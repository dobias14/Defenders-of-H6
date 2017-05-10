using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    public class MultiTargetTower: ThinkingObject, ITower
    {
        private int damage;
        private int hp;
        private Node position;
        public Node Position { get { return position; } set { position = value; } }

        private Status dying;
        private World world;
        private Status aiming;

        private List<ICreature> targets;

        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }

        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }


        public MultiTargetTower(Node position, Graph graph, int damage, int hp, World world)
        {
        	// question - how to get list of all creatures ?
        	List<ICreature> creatures = new List<ICreature>();
        	targets = creatures;
            this.world = world;
            this.damage = damage;
            this.hp = hp;
            this.aiming = new Aiming(world.getarrayOfObjectInGame(), graph,this);
            this.position = position;
            
            base.presentStatus = aiming;

        }

        public override void action()
        {
            if (base.presentStatus.GetType() == typeof(Aiming))
            {
            	for(int i=0;i<targets.Count();i++){
            		targets[i].ReciveDamage(damage);
            	}
            	
            }
   
            else if (base.presentStatus.GetType() == typeof(Dying))
            {
                //do nothing
            }
        }


        public int receiveDamage(int dmg)
        {
            this.hp -= damage;
            return hp;
        }

       
        public bool canBePlaced(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool isDead()
        {
            if (hp <= 0)
            {
                return true;
            }
            return false;
        }

        public override void draw(Graphics g)
        {
            g.DrawString("I AM TOWER", new Font("Comic Sans MS", 15), Brushes.Red,position.getX(),position.getY());
        }

        public Node getPosition()
        {
            return this.position;
        }

        public int getDamage()
        {
            return this.damage;
        }
        public Status getAiming()
        {
            return this.aiming;
        }
        public Status getDying()
        {
            return this.dying;
        }
    }
}

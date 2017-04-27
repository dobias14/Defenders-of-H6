using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    public class BasicTower: ThinkingObject, ITower
    {
        private int damage;
        private int hp;
        private Node position;
        public Node Position { get { return position; } set { position = value; } }

        private Status dying;
        private Status aiming;

        private ICreature target;

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


        public BasicTower(Node position, Graph graph, int damage, int hp)
        {
        	List<ICreature> creatures = new List < ICreature >();
            this.damage = damage;
            this.hp = hp;
            this.aiming = new Aiming(creatures,graph,this);
            this.position = position;
            
            base.presentStatus = aiming;

            //base.presentStatus.onStart();

        }

        public override void action()
        {
            if (base.presentStatus.GetType() == typeof(Aiming))
                //presentStatus is Aiming //lepsie :-)
            {
            	//target = ((Aiming)(aiming)).Target;
            	//target.ReciveDamage(damage);
            	
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
            //g.DrawString("I AM TOWER", new Font("Comic Sans MS", 15), Brushes.Red,position.getX(),position.getY());
            g.FillEllipse(Brushes.Orange, position.getX(), position.getY(), 10, 10);
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

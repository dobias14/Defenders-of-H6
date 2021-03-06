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
        private int waiting;
        private Node position;
        public Node Position { get { return position; } set { position = value; } }
        private World world;

        private Status dying;
        private Status sleeping;
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


        public BasicTower(Node position, Graph graph, int damage, int hp, World world)
        {
            this.damage = damage;
            this.world = world;
            this.hp = hp;
            this.aiming = new Aiming(world.getarrayOfObjectInGame(),graph,this);
            this.sleeping = new Sleeping(this);
            this.dying = new DyingTower(this);
            this.position = position;
            base.presentStatus = null;
            startShooting();

        }

        private void startShooting()
        {
            if (base.presentStatus != null)
            {
                return;
            }
            base.presentStatus = aiming;

            aiming.onStart();
        }

        public override void action()
        {
            if (presentStatus is Aiming)

            {
                target = ((Aiming)(aiming)).Target;
                if (target != null)
                {
                    target.ReciveDamage(damage);
                    this.waiting = 0;
                    base.presentStatus = sleeping;

                }
            }
            else if (presentStatus is Sleeping)
            {
                this.waiting += 1;
            
                if(this.waiting == 5)
                {
                    base.presentStatus = aiming;
                }                              
            }
            else
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
            g.FillEllipse(Brushes.DarkGoldenrod, position.getX(), position.getY(), 15, 15);
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

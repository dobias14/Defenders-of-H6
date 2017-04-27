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


        private Status shooting;
        private Status dying;
        private Status aiming;


        private Node target;

        // private int attackRage;
        //private bool isShooting;
        // private int size;
        //private int X, Y;

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

        public Node Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Node Target
        {
            get
            {
                return target;
            }

            set
            {
                target = value;
            }
        }

        public BasicTower(Node position, Graph graph, int damage, int hp)
        {
            this.damage = damage;
            this.hp = hp;
            //this.target = findTarget(position);

            this.shooting = new ShootBug(this, graph);
            this.aiming = new Aiming();
            this.position = position;

        }

        public override void action()
        {
            throw new NotImplementedException();
        }

       

        public int receiveDamage(int dmg)
        {
            throw new NotImplementedException();
        }

        public void shoot()
        {
            throw new NotImplementedException();
        }

        public bool canBePlaced(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Node findTarget(Node Position)
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
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace DefendersOfH6
{
    public class BasicCreature : ThinkingObject, ICreature
    {
        private static int MIN_RESTING_STEPS = 0;
        private static int MAX_RESTING_STEPS = 2;

        public static string NEGATIVE_DAMAGE = "negative damage";


        public List<Node> path;

        private Node position;
        public Node Position { get { return position; } set { position = value; } }

        private int damage;
        public int Damage { get { return damage; } set { damage = value; } }

        private int hp;
        public int Hp { get { return hp; } set { hp = value; } }

        private World world;
        
        private Status shooting;
        private Status mooving;
        private Status dying;
        private Status resting;

        public BasicCreature(Node position, Node finalDestinantion, Graph graph, int damage, int hp, World world)
        {
            this.position = position;
            this.damage = damage;
            this.hp = hp;

            this.world = world;
            
            this.shooting = new Shooting(this, world);
            this.mooving = new Mooving(this, finalDestinantion, graph);
            this.dying = new Dying(this);
            Random rnd = new Random();
            this.resting = new Resting(this, rnd.Next(MIN_RESTING_STEPS, MAX_RESTING_STEPS));

            base.presentStatus = null;

            commandNewBugToMove();
        }

        private void commandNewBugToMove() {
            if (base.presentStatus != null) {
                return;
            }
            base.presentStatus = mooving;

            mooving.onStart();
        }
        
        
        public override void action()
        {
            if(base.presentStatus.GetType() == typeof(Mooving))
            {
                Node nextPosition = ((Mooving)mooving).NextPosition;
                if (nextPosition.isEnable())
                {
                    this.position = nextPosition;
                }
            }
            else if(base.presentStatus.GetType() == typeof(Shooting))
            {
                int doDamage = ((Shooting)shooting).Damage;
                world.doDamegeToH6Server(doDamage);
            }
            else if(base.presentStatus.GetType() == typeof(Dying))
            {
                //do nothing
            }
        }

        public int ReciveDamage(int damage)
        {
            if(damage < 0)
            {
                throw new ArgumentOutOfRangeException(NEGATIVE_DAMAGE);
            }
            this.hp -= damage;
            return hp;
        }

        public Boolean isDead()
        {
            if (hp <= 0)
            {
                return true;
            }
            return false;
        }

        public Status getDying()
        {
            return this.dying;
        }

        public Status getShooting()
        {
            return this.shooting;
        }

        public Status getMoovnig()
        {
            return this.mooving;
        }

        public Status getResting()
        {
            return this.resting;
        }

        public Node getPosition()
        {
            return this.position;
        }

        public override void draw(Graphics g)
        {
            if (base.presentStatus.GetType() == typeof(Dying))
            {
                g.FillEllipse(Brushes.Red, position.getX(), position.getY(), 15, 15);
            }
            else if (base.presentStatus.GetType() == typeof(Shooting))
            {
                g.FillEllipse(Brushes.Green, position.getX(), position.getY(), 15, 15);
            }
            else
            {
                g.FillEllipse(Brushes.Blue, position.getX(), position.getY(), 15, 15);
            }
            
        }
    }
}

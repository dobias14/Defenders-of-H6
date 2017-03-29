using System;

namespace DefendersOfH6
{
    public class BasicCreature : ThinkingObject, ICreature
    {

        public static string NEGATIVE_DAMAGE = "negative damage";


        private Node position;
        public Node Position { get { return position; } set { position = value; } }

        private int damage;
        public int Damage { get { return damage; } set { damage = value; } }

        private int hp;
        public int Hp { get { return hp; } set { hp = value; } }
        
        private Status shooting;
        private Status mooving;
        private Status dying;

        public BasicCreature(Node position, Node finalDestinantion, Graph graph, int damage, int hp)
        {
            this.position = position;
            this.damage = damage;
            this.hp = hp;
            
            this.shooting = new Shooting(this, graph);
            this.mooving = new Mooving(this, finalDestinantion, graph);
            this.dying = new Dying(this);

            base.presentStatus = mooving;
        }
        
        
        public override void action()
        {
            Node nextPosition = ((Mooving)mooving).NextPosition;
            if (nextPosition.isEnable())
            {
                this.position = nextPosition;
            }
        }

        public override void draw()
        {
            throw new NotImplementedException();
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

        public Node getPosition()
        {
            return this.position;
        }
    }
}
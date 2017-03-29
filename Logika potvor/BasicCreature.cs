using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesV2
{
    class BasicCreature : ThinkingObject, ICreature
    {

        private Node position { get; set; }

        private int damage { get; set; }

        private int hp { get; set; }

        private Status shooting;
        private Status mooving;
        private Status dying;

        public BasicCreature(Node position, int damage, int hp)
        {
            this.position = position;
            this.damage = damage;
            this.hp = hp;

            this.shooting = new Shooting(this);
            this.mooving = new Mooving(this);
            this.dying = new Dying(this);

            base.presentStatus = mooving;
        }
        
        
        public override void action()
        {
            throw new NotImplementedException();
            
        }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public int ReciveDamage(int damage)
        {
            return this.damage -= damage;
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
    }
}

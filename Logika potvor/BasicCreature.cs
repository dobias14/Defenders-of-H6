using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

/*
             * vyratam si najkratsiu cestu do cieloveho vrchola(floyd)
             * zistims si cestum*
             * ak este niesom pri vrchole spravim krok
             * zistim ci mozem po niekom utocit
             * ak uz som pri vrchole, alebo mozem utocit srielam(na dialku/iba na blizko)
             * (dam niekomu damage)
             */

/*
 * beriem od niekoho damage(pri strelbe na mna)
 * som mrtvy? ak nula zivota
 */

/*
 * incicalizacia -
 * kolko mam zivota
 * kde sa nachadzam
 */

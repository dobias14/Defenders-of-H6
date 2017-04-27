using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefendersOfH6
{
    public class RoundGovernor
    {
        volatile bool running = false;
        Graphics g;
        volatile private int sleepingTimeLength = 17;//60 fps

        volatile List<ThinkingObject> arrayOfObject;

        ICollection myCollection;


        public RoundGovernor(bool isRunning, List<ThinkingObject> arrayOfObjectInGame, Graphics g)
        {
            running = isRunning;
            this.g = g;
            Console.WriteLine("som tu");
            Console.WriteLine(arrayOfObjectInGame.Count);
            this.arrayOfObject = arrayOfObjectInGame;
            Console.WriteLine(arrayOfObjectInGame.Count);

            myCollection = ArrayList.Synchronized(arrayOfObject);
        }

        public void nastavFPS( double pocetFPS) {
            int pocetMilisekundNa1Akciu = (int)Math.Round((1000 / pocetFPS), MidpointRounding.ToEven);          
            setSleepingTimeLength(pocetMilisekundNa1Akciu);
        }

        public void stopThread()
        {
            running = false;
        }

        public void setSleepingTimeLength(int newTime)
        {
            this.sleepingTimeLength = newTime;
        }

        public void setArray(List<ThinkingObject> newArray)
        {

            // myCollection = ArrayList.Synchronized(arrayOfObject);

            lock (myCollection.SyncRoot)
            {
                arrayOfObject = newArray;
            }

        }


        public void run()
        {
             //myCollection = ArrayList.Synchronized(arrayOfObject);
            while (running){
                //World.addOneTick();
                Thread.Sleep(sleepingTimeLength);
                Console.WriteLine("som tu");
                Console.WriteLine(arrayOfObject.Count);

                lock (myCollection.SyncRoot) {
                    foreach (ThinkingObject objectinGame in arrayOfObject)
                    {
                        objectinGame.thinking();
                    }

                    foreach (ThinkingObject objectinGame in arrayOfObject)
                    {
                        objectinGame.action();
                    }

                    foreach (ThinkingObject objectinGame in arrayOfObject)
                    {
                       
                        objectinGame.draw(g);
                    }
                }
               /* if (form1 != null)
                {
                    form1.Invalidate();
                }*/
            }
        }
    }
}

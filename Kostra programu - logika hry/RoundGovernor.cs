using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    class RoundGovernor
    {
        volatile bool running = false;
        private Form1 form1;
        volatile private int sleepingTimeLength = 17;//60 fps

        List<ThinkingObject> arrayOfObject;


        public RoundGovernor(bool isRunning, List<ThinkingObject> arrayOfObjectInGame)
        {
            running = isRunning;
            form1 = null;
            this.arrayOfObject = arrayOfObjectInGame;
        }

        public void stopThread()
        {
            running = false;
        }

        public void setSleepingTimeLength(int newTime)
        {
            this.sleepingTimeLength = newTime;
        }


        public void run()
        {
            while (running)
            {
                World.addOneTick();
                Thread.Sleep(sleepingTimeLength);

                foreach (ThinkingObject objectinGame in arrayOfObject) {
                    objectinGame.thinking();
                    objectinGame.action();
                    objectinGame.draw();
                }
                if (form1 != null)
                {
                    form1.Invalidate();
                }
            }
        }
    }
}

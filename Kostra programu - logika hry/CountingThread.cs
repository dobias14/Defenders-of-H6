using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    class CountingThread
    {
        bool running = false;
        private Form1 form1;

        public CountingThread(bool isRunning) {
            running = isRunning;
        }

        public CountingThread(bool isRunning, Form1 form1) : this(isRunning)
        {
            this.form1 = form1;
        }

        public void stopThread() {
            running = false;
        }


    public void run() {
            while (running) {
                World.addOneTick();
                Thread.Sleep(1000);
                form1.Invalidate();
            }
        }
    }
}

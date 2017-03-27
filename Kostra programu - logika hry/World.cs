using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    class World
    {
        static bool working = false;
        private static int time = 0;

        public World() {
            CountingThread clock = new CountingThread(true);

            Thread oThread = new Thread(new ThreadStart(clock.run));

            // Start the thread
            oThread.Start();

            // Spin for a while waiting for the started thread to become
            // alive:
            while (!oThread.IsAlive) ;

            // Put the Main thread to sleep for 1 millisecond to allow oThread
            // to do some work:
            Thread.Sleep(1);

            // Request that oThread be stopped
            oThread.Abort();

            // Wait until oThread finishes. Join also has overloads
            // that take a millisecond interval or a TimeSpan object.
            oThread.Join();

            Console.WriteLine();
            Console.WriteLine("clock has finished.");
        }

        public static int getTime() {
            return time;
        }

        public static void addOneTick()
        {
            time++;
        }
        public static void resetTimer()
        {
            time = 0;
        }


    }
}

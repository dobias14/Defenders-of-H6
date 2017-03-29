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
        private static int time = 0;
        private List<ThinkingObject> arrayOfObjectInGame = new List<ThinkingObject>();
        private RoundGovernor manazerKola = null;
        private Thread thread = null;


        public World(List<ThinkingObject> objectInGame){
            manazerKola = new RoundGovernor(true, arrayOfObjectInGame);
            thread = new Thread(new ThreadStart(manazerKola.run));
            arrayOfObjectInGame = objectInGame;
        }

        private void startThread() {
            if (manazerKola == null) {
                manazerKola = new RoundGovernor(true, arrayOfObjectInGame);
            }
            if (thread == null) {
                thread = new Thread(new ThreadStart(manazerKola.run));
            }

            // Start the thread
            thread.Start();

            // Spin for a while waiting for the started thread to become
            // alive:
            while (!thread.IsAlive) ;
        }

        private void stopThread() {
            manazerKola.stopThread();
            thread.Join();
            thread = null;
            manazerKola = null;
        }

        public void zacniKolo() {
            startThread();
        }

        public void skonciKolo() {
            stopThread();
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

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
        private List<ThinkingObject> arrayOfObjectInGame = new List<ThinkingObject>();
        private RoundGovernor manazerKola = null;
        private Thread thread = null;

        private int lifeOfH6ServerPc = 0;
        private int score = 0;


        public World(List<ThinkingObject> objectInGame, int startingLifeOfH6Server){
            manazerKola = new RoundGovernor(true, arrayOfObjectInGame);
            thread = new Thread(new ThreadStart(manazerKola.run));
            arrayOfObjectInGame = objectInGame;

            setLifeOfH6ServerPc(startingLifeOfH6Server);
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

        public void doDamegeToH6Server(int amountOfDamage){
            if (amountOfDamage > lifeOfH6ServerPc){
                lifeOfH6ServerPc = 0;
            }
            else {
                lifeOfH6ServerPc -= amountOfDamage;
            }
            
        }

        private void setLifeOfH6ServerPc(int newLife){
            lifeOfH6ServerPc = newLife;
        }

        public int getLifeOfH6ServerPc() {
            return lifeOfH6ServerPc;
        }


        private void setScore(int newScore){
            score = newScore;
        }

        public void addToScore(int scoreToAdd){
            score += scoreToAdd;
        }

        public void resetScore(){
            score = 0;
        }

        public int getScore(){
            return score;
        }


    }
}

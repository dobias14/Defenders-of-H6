using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace DefendersOfH6
{
    public class World
    {
        private List<ThinkingObject> arrayOfObjectInGame = new List<ThinkingObject>();
        private RoundGovernor manazerKola = null;
        private Thread thread = null;

        private int lifeOfH6ServerPc = 0;
        private int score = 0;
        private int actualFPS = 60;

        private Graphics g;


        /*
        public World(ref  List<ThinkingObject> objectInGame, int startingLifeOfH6Server,Graphics g){
            arrayOfObjectInGame = objectInGame;
            this.g = g;

            setLifeOfH6ServerPc(startingLifeOfH6Server);
            setScore(500);
        }
        */

        public World(ref List<ThinkingObject> objectInGame, int startingLifeOfH6Server, int startingScore, Graphics g)
        {
            arrayOfObjectInGame = objectInGame;
            this.g = g;

            setLifeOfH6ServerPc(startingLifeOfH6Server);
            setScore(startingScore);
        }

        private void startThread() {
            if (manazerKola == null) {
                manazerKola = new RoundGovernor(true, ref arrayOfObjectInGame, g);
            }
            if (thread == null) {
                thread = new Thread(new ThreadStart(manazerKola.run));
            }

            manazerKola.nastavFPS(actualFPS);
            // Start the thread
            thread.Start();

            // Spin for a while waiting for the started thread to become
            // alive:
            while (!thread.IsAlive) ;
        }

        private void stopThread() {
            manazerKola.stopThread();
            RoundGovernor.running = false;
            thread.Join();
            thread = null;
            manazerKola = null;
        }

        public void zacniKolo() {
            startThread();
            Thread.Sleep(1);
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

        public void substractFromScore(int costOfTower)
        {
            score -= costOfTower;
        }

        public void resetScore(){
            score = 0;
        }

        public int getScore(){
            return score;
        }



        public void setArray(List<ThinkingObject> newArray)
        {

            ICollection myCollection = ArrayList.Synchronized(arrayOfObjectInGame);

            lock (myCollection.SyncRoot)
            {
                arrayOfObjectInGame = newArray;
            }
            
        }

        public void setFPS(int newFPS) {
            actualFPS = newFPS;
            if (manazerKola != null) {
                manazerKola.nastavFPS(newFPS);
            }
        }


    }
}

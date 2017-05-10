using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Collections;

namespace DefendersOfH6
{
    public class World
    {

        public enum Difficulty
        {
            None,
            Easy,
            Regular,
            Hard,
            Insane
        }

        private ICollection myCollection;


        private List<ThinkingObject> arrayOfObjectInGame = new List<ThinkingObject>();
        private RoundGovernor manazerKola = null;
        private Thread thread = null;

        private int lifeOfH6ServerPc = 0;
        private int score = 0;
        private int pointsForOneBug = 0;
        private int actualFPS = 60;
        private Difficulty difficultyOfRound = Difficulty.None;

        private Graphics g;
        private Graph graph;

        public World(ref List<ThinkingObject> objectInGame, Difficulty difficulty, Graphics g, Graph graph)
        {
            arrayOfObjectInGame = objectInGame;
            this.g = g;
            this.graph = graph;
            difficultyOfRound = difficulty;

            setLifeOfH6ServerPcANDsetScore();

            myCollection = ArrayList.Synchronized(arrayOfObjectInGame);
        }

        public void setDifficultyForNextRound(Difficulty newDifficultyOfRound)
        {
            if (RoundGovernor.running == false) {
                difficultyOfRound = newDifficultyOfRound;
            }           
        }

        public void zacniKolo()
        {
            startThread();
            Thread.Sleep(1);
        }

        //vracia kolko bugov bolo zabitych toto kolo
        public void skonciKolo()
        {
            stopThread();
            addToScore(vycistiPlochuOdMrtvol() * pointsForOneBug);
        }

        public void doDamegeToH6Server(int amountOfDamage)
        {
            if (amountOfDamage > lifeOfH6ServerPc)
            {
                lifeOfH6ServerPc = 0;
            }
            else
            {
                lifeOfH6ServerPc -= amountOfDamage;
            }

        }

        public bool isH6ServerDead()
        {
            return lifeOfH6ServerPc < 0;
        }

        public void showEndOfTheGame() {
            System.Console.WriteLine("H6 server has been destroyed.");
            //throw new System.NotImplementedException("H6 server has been destroyed.");            
        }

        public void addToScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }

        public void substractFromScore(int costOfTower)
        {
            score -= costOfTower;
        }

        public void resetScore()
        {
            score = 0;
        }

        public int getScore()
        {
            return score;
        }



        public void setArray(List<ThinkingObject> newArray)
        {

            lock (myCollection.SyncRoot)
            {
                arrayOfObjectInGame = newArray;
            }

        }

        public List<ThinkingObject> getarrayOfObjectInGame() {
            return arrayOfObjectInGame;
        }

        public void setFPS(int newFPS)
        {
            actualFPS = newFPS;
            if (manazerKola != null)
            {
                manazerKola.nastavFPS(newFPS);
            }
        }



        private void startThread() {
            if (difficultyOfRound == Difficulty.None ) {
                if (isH6ServerDead())
                {
                    System.Console.WriteLine("H6 server has been destroyed.");
                }
                return;
            }
            if (manazerKola == null) {
                manazerKola = new RoundGovernor(true, ref arrayOfObjectInGame, g, this, graph, difficultyOfRound);
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

        private int  vycistiPlochuOdMrtvol() {
            lock (myCollection.SyncRoot)
            {
                return arrayOfObjectInGame.RemoveAll(objectinGame => objectinGame.presentStatus is Dying);
            }
        }

        private void setLifeOfH6ServerPcANDsetScore(){
            int newLife = 0;
            int newScoreValueOfBug = 0;
            int newScore = 0;
            switch (difficultyOfRound){
                case Difficulty.Easy:
                    {
                        newLife = 500;
                        newScore = 5000;
                        newScoreValueOfBug = 100;
                        break;
                    }
                case Difficulty.Regular:
                    {
                        newLife = 300;
                        newScore = 1000;
                        newScoreValueOfBug = 50;
                        break;
                    }
                case Difficulty.Hard:
                    {
                        newLife = 100;
                        newScore = 500;
                        newScoreValueOfBug = 10;
                        break;
                    }
                case Difficulty.Insane:
                    {
                        newLife = 1;
                        newScore = 100;
                        newScoreValueOfBug = 1;
                        break;
                    }
                case Difficulty.None:
                    {
                        break;
                    }
            }
            lifeOfH6ServerPc = newLife;
            score = newScore;
            pointsForOneBug = newScoreValueOfBug;
        }

    }
}

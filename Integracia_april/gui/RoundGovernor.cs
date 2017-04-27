using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace DefendersOfH6
{
    public class RoundGovernor
    {

        private enum Smer {
            Sever,Juh,Vychod,Zapad
        }

        public static volatile bool running;

        volatile private int sleepingTimeLength = 17;//60 fps

        private volatile int timeTillNextSpawn = 0;
        private int howManyToSpawn = 0;
 
        private Graphics g;
        private World world;
        private Graph graph;
        private World.Difficulty difficultyOfRound;

        private List<ThinkingObject> arrayOfObject;


        ICollection myCollection;


        public RoundGovernor(bool isRunning,ref List<ThinkingObject> arrayOfObjectInGame,
            Graphics g, World world, Graph graph, World.Difficulty difficultyOfRound)
        {
            running = isRunning;

            this.g = g;                   
            this.world = world;
            this.graph = graph;
            this.difficultyOfRound = difficultyOfRound;

            arrayOfObject = arrayOfObjectInGame;

            myCollection = ArrayList.Synchronized(arrayOfObject);

            setParameters();
        }

        private void setParameters() {
            switch (difficultyOfRound)
            {
                case World.Difficulty.Easy:
                {
                        howManyToSpawn = 5;
                        timeTillNextSpawn = 300;
                        break;
                }
                case World.Difficulty.Regular:
                    {
                        howManyToSpawn = 10;
                        timeTillNextSpawn = 250;
                        break;
                    }
                case World.Difficulty.Hard:
                    {
                        howManyToSpawn = 15;
                        timeTillNextSpawn = 200;
                        break;
                    }
                case World.Difficulty.Insane:
                    {
                        howManyToSpawn = 100;
                        timeTillNextSpawn = 100;
                        break;
                    }
                case World.Difficulty.None:
                    {
                        break;
                    }        
            }
        }

        private void resetTimeTillNextSpawn() {
            switch (difficultyOfRound)
            {
                case World.Difficulty.Easy:
                    {
                        timeTillNextSpawn = new Random().Next(200)+50;
                        break;
                    }
                case World.Difficulty.Regular:
                    {
                        timeTillNextSpawn = new Random().Next(50) + 30;
                        break;
                    }
                case World.Difficulty.Hard:
                    {
                        timeTillNextSpawn = new Random().Next(30) + 15;
                        break;
                    }
                case World.Difficulty.Insane:
                    {
                        timeTillNextSpawn = new Random().Next(10) + 5;
                        break;
                    }
                case World.Difficulty.None:
                    {
                        break;
                    }
            }
        }

        // tu potrebujem funkcionalitu ku grafu graph.getWidth;graph.getHeight
        private Node getPositionOfNewBug() {
            Random random = new Random();
            Smer odkialPojdeBug = (Smer) random.Next(Enum.GetNames(typeof(Smer)).Length);
            switch (odkialPojdeBug) {
                case Smer.Sever:
                    {
                        return graph.getNode(random.Next(graph.getWidth()-1),0);
                    }
                case Smer.Juh:
                    {
                        return graph.getNode(random.Next(graph.getWidth() - 1), graph.getHeight()-1);
                    }
                case Smer.Vychod:
                    {
                        return graph.getNode(graph.getWidth()-1, random.Next(graph.getHeight() - 1));
                    }
                case Smer.Zapad:
                    {
                        return graph.getNode(0, random.Next(graph.getHeight() - 1));
                    }
            }

            return null;
        }

        private int getAmountOfBugsInArray() {
            int howManyBugs = 0;
            lock (myCollection.SyncRoot)
            {
                foreach (ThinkingObject objectinGame in arrayOfObject)
                {
                    if (objectinGame is ICreature) {
                        howManyBugs++;
                    }
                }
            }
            return howManyBugs;
        }

        private void spawnCreature(Node ciel) {
            if (getAmountOfBugsInArray() <= howManyToSpawn) {
                if (timeTillNextSpawn <= 0)
                {
                    BasicCreature newBug = new BasicCreature(getPositionOfNewBug(), ciel,
                        graph, 100, 100, world);
                    lock (myCollection.SyncRoot)
                    {
                        arrayOfObject.Add(newBug);
                    }
                    resetTimeTillNextSpawn();
                }
                else
                {
                    timeTillNextSpawn--;
                }
            }
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
            //graph.draw(g);
            while (running){
                //World.addOneTick();
                Thread.Sleep(sleepingTimeLength);

                spawnCreature(graph.getNode(10,10));

                //g.Clear(Color.White);
                graph.draw(g);

                lock (myCollection.SyncRoot) {
                    
                    
                    foreach (ThinkingObject objectinGame in arrayOfObject)
                    {
                        objectinGame.thinking();
                    }                    
                    foreach (ThinkingObject objectinGame in arrayOfObject)
                    {
                        objectinGame.action();
                    }

                    //g.Clear(Color.White);

                    //graph.draw(g);

                    foreach (ThinkingObject objectinGame in arrayOfObject)
                    {
                       
                        objectinGame.draw(g);
                    }
                }
                if (world.isH6ServerDead()) {
                    //TO DO sprava ze prehral tu bude
                    world.skonciKolo();
                }
            }
        }
    }
}

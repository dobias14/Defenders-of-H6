using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefendersOfH6
{
    class Resting : Status
    {
        private ICreature creature;
        private int waitingSteps;
        public int WaitingSteps { get { return waitingSteps; } }
        private int counter;
        public int Counter { get { return counter; } }

        public Resting(ICreature creature, int waitingSteps)
        {
            this.creature = creature;
            this.waitingSteps = waitingSteps;
            this.counter = 0;
            Console.WriteLine(waitingSteps);
        }

        public Status changeStatus()
        {
            if (counter <= 0)
            {
                counter = waitingSteps;
                return this.creature.getMoovnig();
            }
            return null;
        }

        public void onEnd()
        {
            //do nothing
        }

        public void onStart()
        {
            counter = waitingSteps;
        }

        public void prepare()
        {
            counter--;
        }
    }
}

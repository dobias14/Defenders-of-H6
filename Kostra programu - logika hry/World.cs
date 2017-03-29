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
            /*
            while(working){
            MyCar auto = new MyCar();//implmements ThinkingObject

            auto.thinking();
            auto.action();
            auto.draw();
            clock.tick();//this will be tread probably - this is just example 
            }
            */
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

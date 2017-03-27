using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    abstract class ThinkingObject
    {
        public Status presentStatus;

        public Status thinking()
        {
            if (presentStatus == null)
            {//exception
                return null;
            }
            Status novyStav = presentStatus.changeStatus();
            if (novyStav != null)
            {//nastala zmena
                presentStatus.onEnd();
                novyStav.onStart();
                novyStav.prepare();
                return novyStav;
            }
            else
            {//vsetko je po starom a vykonam to co mam robit teraz bez zmeny
                presentStatus.prepare();
                return presentStatus;
            }
        }
        // vykonam to co som si pripravil v Status.prepare(); a podobnych metodach ako Status.onEnd() a Status.onStart()
        public abstract void action();
        //
        public abstract void draw();
    }
}

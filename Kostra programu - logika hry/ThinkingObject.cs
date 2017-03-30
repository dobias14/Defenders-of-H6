using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6{
    
    public abstract class ThinkingObject{
        public Status presentStatus;

        public void thinking(){
            if (presentStatus == null){//exception
                return;
            }
            Status novyStav = presentStatus.changeStatus();
            if (novyStav != null){//nastala zmena
                presentStatus.onEnd();
                novyStav.onStart();
                novyStav.prepare();
                this.presentStatus = novyStav;
            }
            else{//vsetko je po starom a vykonam to co mam robit teraz bez zmeny
                presentStatus.prepare();
            }
        }
        // vykonam to co som si pripravil v Status.prepare(); a podobnych metodach ako Status.onEnd() a Status.onStart()
        public abstract void action();
        // tu treba definovat ako sa objekt bude zobrazovat pouzivatelovi
        public abstract void draw();
    }
}

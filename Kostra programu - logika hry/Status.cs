using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    interface Status
    {
        // nainicializujem  vsetko co potrebujem
        void onStart();
        // tu vykonava to co ten onkretny stav a - napirkald spi - sa bude vykonavas spanok
        void prepare();
        // ukonci co potrebujes
        void onEnd();

        // tu budu testy a podla nich menim stav a ten vracam - ak nie je zmena vraciam null
        Status changeStatus();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{
    public interface Status
    {
        // nainicializujem vsetko co potrebujem
        void onStart();
        // tu sa pripravuju premenne na vykonanie - tie sa vykonaju v ThinkingObject::action() fazy hry
        void prepare();
        // ukonci co potrebujes
        void onEnd();

        // tu budu testy a podla vraciam novy vnutorny stav - ak nie je zmena vraciam null
        // POZOR : svoj vnutorny stav nemenim - to robi ThinkingObject::thinking()
        Status changeStatus();
    }
}

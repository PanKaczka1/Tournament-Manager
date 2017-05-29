using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    enum Disc { Volleyball, RopeDragging, Dodgeball };
    class Tournament
    {
        private Contest contestVolleyball;
        private Contest contestRopeDragging;
        private Contest contestDodgeball;
        public Tournament()
        {
            contestVolleyball = new Contest(Disc.Volleyball);
            contestRopeDragging = new Contest(Disc.RopeDragging);
            contestDodgeball = new Contest(Disc.Dodgeball);

        }
        public void saveState(string filename)
        {

        }
        public void loadState(string filename)
        {

        }
    }
}

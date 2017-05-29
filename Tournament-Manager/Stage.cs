using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class Stage
    {
        protected List<Match> matches;
        public Stage()
        {
            matches = new List<Match>();
        }
        public virtual void printScores()
        {
        }
        public virtual void printSchedule()
        {
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class Stage
    {
        protected ArrayList matches = new ArrayList();
        public virtual void printScores()
        {
        }
        public virtual void printSchedule()
        {
        }
    }
}

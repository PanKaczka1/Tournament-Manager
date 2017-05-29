using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class Cup : Stage
    {
        private Match semifinal1;
        private Match semifinal2;
        private Match final;
        public Match Semifinal1
        {
            get { return semifinal1; }
            set { semifinal1 = value; }
        }
        public Match Semifinal2
        {
            get { return semifinal2; }
            set { semifinal2 = value; }
        }
        public Match Final
        {
            get { return final; }
            set { final = value; }
        }
        public override void printScores()
        {

        }
        public override void printSchedule()
        {

        }
    }
}

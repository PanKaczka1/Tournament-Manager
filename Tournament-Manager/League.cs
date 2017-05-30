using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class League : Stage
    {
        private ObservableCollection<Match> matches;
        public League()
        {
            matches = new ObservableCollection<Match>();
        }
        public ObservableCollection<Match> Matches
        {
            get { return matches; }
        }
        public override void printScores()
        {

        }
        public override void printSchedule()
        {

        }
    }
}

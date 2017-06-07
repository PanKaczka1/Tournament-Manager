using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    [Serializable]
    public class League : Stage
    {
        private ObservableCollection<Match> matches;
        private ObservableCollection<Match> playedMatches;
        public League()
        {
            matches = new ObservableCollection<Match>();
            playedMatches = new ObservableCollection<Match>();
        }
        public ObservableCollection<Match> Matches
        {
            get { return matches; }
        }
        public ObservableCollection<Match> PlayedMatches
        {
            get { return playedMatches; }
        }
    }
}

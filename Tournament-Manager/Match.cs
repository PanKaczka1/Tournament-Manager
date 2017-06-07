using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    [Serializable]
    public abstract class Match
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        protected uint Points1 { get; set; }
        protected uint Points2 { get; set; }
        protected Referee[] referees;
        public Team Winner { get; set; }

        public abstract void Play();
        public abstract uint WinningPoints();
        public abstract uint LosingPoints();
    }
}

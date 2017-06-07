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
        public Team Team1 { get; protected set; }
        public Team Team2 { get; protected set; }
        public uint Points1 { get; protected set; }
        public uint Points2 { get; protected set; }
        protected Referee[] referees;
        protected static uint Counter = 0;
        public Team Winner { get; set; }
        public uint Id { get; protected set; }

        public abstract void Play();
        public abstract uint WinningPoints();
        public abstract uint LosingPoints();
    }
}

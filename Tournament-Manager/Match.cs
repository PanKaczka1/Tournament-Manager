using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    [Serializable]
    public abstract class Match : IEquatable<Match>
    {
        public Team Team1 { get; protected set; }
        public Team Team2 { get; protected set; }
        public uint Points1 { get; protected set; }
        public uint Points2 { get; protected set; }
        protected Referee[] referees;
        protected static int Counter = 0;
        public Team Winner { get; set; }
        public int Id { get; protected set; }

        public abstract void Play();
        public abstract uint WinningPoints();
        public abstract uint LosingPoints();
        public abstract bool Equals(Match match);
    }
}

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
        public Referee[] referees { get; protected set; }
        public Team Team1 { get; protected set; }
        public Team Team2 { get; protected set; }
        public uint Points1 { get; protected set; }
        public uint Points2 { get; protected set; }
        public Team Winner { get; protected set; }
        public String Description { get; protected set; }

        public abstract void Play();
        public abstract uint WinningPoints();
        public abstract uint LosingPoints();
        public abstract bool Equals(Match match);
    }
}

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
        protected Team team1, team2;
        protected Team winner;
        public Team Winner
        {
            get { return winner; }
            set { winner = value; }
        }
        protected Referee[] referees;

        public abstract void Play(int points1, int points2);
        public abstract uint WinningPoints();
        public abstract uint LosingPoints();
    }
}

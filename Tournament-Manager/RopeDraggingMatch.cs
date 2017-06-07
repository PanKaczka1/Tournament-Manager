using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    [Serializable]
    public class RopeDraggingMatch : Match
    {
        public RopeDraggingMatch(Team t1, Team t2)
        {
            Team1 = t1;
            Team2 = t2;
        }
        public RopeDraggingMatch(Team t1, Team t2, uint p1, uint p2, Referee r)
        {
            Team1 = t1;
            Team2 = t2;
            Points1 = p1;
            Points2 = p2;
            referees = new Referee[1];
            this.referees[0] = r;
        }
        public override void Play()
        {
            Team1.MatchesNo++;
            Team2.MatchesNo++;
            if (Points1 > Points2)
            {
                Winner = Team1;
                Team1.Points += this.WinningPoints();
                Team2.Points += this.LosingPoints();
            } else
            {
                Winner = Team2;
                Team1.Points += this.LosingPoints();
                Team2.Points += this.WinningPoints();
            }
        }
        public override uint WinningPoints()
        {
            return 1;
        }
        public override uint LosingPoints()
        {
            return 0;
        }
        public override bool Equals(Match match)
        {
            return (this.Team1.Name.Equals(match.Team1.Name) && (this.Team2.Name.Equals(match.Team2.Name)));
        }
    }
}

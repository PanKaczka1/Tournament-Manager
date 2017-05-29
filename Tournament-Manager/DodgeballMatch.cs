using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class DodgeballMatch : Match
    {
        public DodgeballMatch(Team t1, Team t2, Referee referee)
        {
            team1 = t1;
            team2 = t2;
            referees = new Referee[1];
            referees[0] = referee;
        }
        public override void Play(int points1, int points2)
        {
            if (points1 > points2)
            {
                winner = team1;
                team1.Points += this.WinningPoints();
                team2.Points += this.LosingPoints();
            } else
            {
                winner = team2;
                team1.Points += this.LosingPoints();
                team2.Points += this.WinningPoints();
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
    }
}

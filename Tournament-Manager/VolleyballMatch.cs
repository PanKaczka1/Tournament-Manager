using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class VolleyballMatch : Match
    {
        public VolleyballMatch (Team t1, Team t2)
        {
            team1 = t1;
            team2 = t2;
        }
        public override void Play(int points1, int points2)
        {
            if (points1 > points2)
            {
                winner = team1;
                if (points2 == 2)
                {
                    team1.Points += 2;
                    team2.Points += 1;
                } else
                {
                    team1.Points += WinningPoints();
                    team2.Points += LosingPoints();
                }
            } else
            {
                winner = team2;
                if (points1 == 2)
                {
                    team1.Points += 1;
                    team2.Points += 2;
                }
                else
                {
                    team1.Points += LosingPoints();
                    team2.Points += WinningPoints();
                }
            }
        }
        public override uint WinningPoints()
        {
            return 3;
        }
        public override uint LosingPoints()
        {
            return 0;
        }
        
    }
}

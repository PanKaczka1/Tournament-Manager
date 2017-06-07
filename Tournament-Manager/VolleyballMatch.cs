using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csUnit;

namespace Tournament_Manager
{
    [Serializable]
    public class VolleyballMatch : Match
    {
        public VolleyballMatch (Team t1, Team t2)
        {
            Team1 = t1;
            Team2 = t2;
        }

        public VolleyballMatch (Team t1, Team t2, String description)
        {
            Team1 = t1;
            Team2 = t2;
            this.Description = description;
        }
        public VolleyballMatch(Team t1, Team t2, uint p1, uint p2, Referee[] referees, String desc)
        {
            Team1 = t1;
            Team2 = t2;
            Points1 = p1;
            Points2 = p2;
            this.referees = referees;
            Description = desc;
        }
        public override void PlayCup()
        {
            if(Points1 > Points2)
            {
                Winner = Team1;
            }
            else
            {
                Winner = Team2;
            }
        }
        public override void Play()
        {
            Team1.MatchesNo++;
            Team2.MatchesNo++;
            if (Points1 > Points2)
            {
                Winner = Team1;
                if (Points2 == 2)
                {
                    Team1.Points += 2;
                    Team2.Points += 1;
                } else
                {
                    Team1.Points += WinningPoints();
                    Team2.Points += LosingPoints();
                }
            } else
            {
                Winner = Team2;
                if (Points1 == 2)
                {
                    Team1.Points += 1;
                    Team2.Points += 2;
                }
                else
                {
                    Team1.Points += LosingPoints();
                    Team2.Points += WinningPoints();
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
        public String getName1()
        {
            return Team1.Name;
        }
        public override bool Equals(Match match)
        {
            return (this.Team1.Name.Equals(match.Team1.Name) && (this.Team2.Name.Equals(match.Team2.Name)));
        }
    }
}

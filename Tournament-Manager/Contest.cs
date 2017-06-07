using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

    
namespace Tournament_Manager
{
    [Serializable]
    public class Contest
    {
        protected ObservableCollection<Team> teams;
        protected ObservableCollection<Referee> referees;
        protected League league;
        protected Cup cup;
        protected Disc discipline;
        protected uint teamsAmount;

        public uint TeamsAmount
        {
            get { return teamsAmount; }
            set { teamsAmount = value; }
        }
        public Disc Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }
        public League League
        {
            get { return league; }
        }
        public Cup Cup
        {
            get { return cup; }
        }
        public ObservableCollection<Team> Teams
        {
            get { return teams; }
        }
        public ObservableCollection<Referee> Referees
        {
            get { return referees; }
        }
        public Contest(Disc discipline)
        {
            teams = new ObservableCollection<Team>();
            referees = new ObservableCollection<Referee>();
            league = new League();
            cup = new Cup();
            teamsAmount = 4;
            this.discipline = discipline;
        }
        public void generateSemifinals() 
        {
            switch (Discipline)
            {
                case Disc.Volleyball:
                    cup.Semifinal1 = new VolleyballMatch(teams[0], teams[3]);
                    cup.Semifinal2 = new VolleyballMatch(teams[1], teams[2]);
                    league.Matches.Add(cup.Semifinal1);
                    league.Matches.Add(cup.Semifinal2);
                    break;
                case Disc.RopeDragging:
                    cup.Semifinal2 = new RopeDraggingMatch(teams[1], teams[2]);
                    cup.Semifinal1 = new RopeDraggingMatch(teams[0], teams[3]);
                    break;
                case Disc.Dodgeball:
                    cup.Semifinal1 = new DodgeballMatch(teams[0], teams[3]);
                    cup.Semifinal2 = new DodgeballMatch(teams[1], teams[2]);
                    break;
            }
        }

        public void generateFinals()
        {
            switch (Discipline)
            {
                case Disc.Volleyball:
                    cup.Final = new VolleyballMatch(league.PlayedMatches[league.PlayedMatches.Count-1].Winner, league.PlayedMatches[league.PlayedMatches.Count-2].Winner);
                    league.Matches.Add(cup.Final);
                    break;
                case Disc.RopeDragging:
                    cup.Final = new RopeDraggingMatch(cup.Semifinal1.Winner, cup.Semifinal2.Winner);
                    break;
                case Disc.Dodgeball:
                    cup.Final = new DodgeballMatch(cup.Semifinal1.Winner, cup.Semifinal2.Winner);
                    break;
            }
        }
        public void generateCupStage()
        {
            if (League.Matches.Count() == 0)
            {
                if (Cup.Semifinal1 == null)
                {
                    generateSemifinals();
                }
                else
                {
                    if (Cup.Final == null)
                    {
                        generateFinals();
                    }
                }
            }
        }
        public void addTeam(Team team)
        {
            teams.Add(team);
        }
        public void removeTeam(Team team)
        {
            teams.Remove(team);
        }
        public void addReferee(Referee referee)
        {
            referees.Add(referee);
        }
        public void removeReferee(Referee referee)
        {
            referees.Remove(referee);
        }
    }
}

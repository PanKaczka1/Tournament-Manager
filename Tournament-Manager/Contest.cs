using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    
namespace Tournament_Manager
{
    class Contest
    {
        protected List<Team> teams;
        protected List<Referee> referees;
        protected League league;
        protected Cup cup;
        protected Disc discipline;
        public Disc Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }
        public Contest(Disc discipline)
        {
            teams = new List<Team>();
            referees = new List<Referee>();
            league = new League();
            cup = new Cup();
            this.discipline = discipline;
        }
        public void generateSemifinals()
        {
            List<Team> SortedList = teams.OrderByDescending(o => o.Points).ToList();
            Random rnd = new Random();
            if (Discipline == Disc.Volleyball)
            {
                cup.Semifinal1 = new VolleyballMatch(teams[0], teams[3], referees[rnd.Next(referees.Count - 1)], referees[rnd.Next(referees.Count - 1)], referees[rnd.Next(referees.Count - 1)]);
                cup.Semifinal2 = new VolleyballMatch(teams[1], teams[2], referees[rnd.Next(referees.Count - 1)], referees[rnd.Next(referees.Count - 1)], referees[rnd.Next(referees.Count - 1)]);
            }
            else if (Discipline == Disc.RopeDragging)
            {
                cup.Semifinal1 = new RopeDraggingMatch(teams[0], teams[3], referees[rnd.Next(referees.Count - 1)]);
                cup.Semifinal2 = new RopeDraggingMatch(teams[1], teams[2], referees[rnd.Next(referees.Count - 1)]);
            }
            else if (Discipline == Disc.Dodgeball)
            {
                cup.Semifinal1 = new DodgeballMatch(teams[0], teams[3], referees[rnd.Next(referees.Count - 1)]);
                cup.Semifinal2 = new DodgeballMatch(teams[1], teams[2], referees[rnd.Next(referees.Count - 1)]);
            }
        }
        public void generateFinals()
        {
            Random rnd = new Random();
            if (Discipline == Disc.Volleyball)
            {
                cup.Final = new VolleyballMatch(cup.Semifinal1.Winner, cup.Semifinal2.Winner, referees[rnd.Next(referees.Count - 1)], referees[rnd.Next(referees.Count - 1)], referees[rnd.Next(referees.Count - 1)]);
            }
            else if (Discipline == Disc.RopeDragging)
            {
                cup.Final = new RopeDraggingMatch(cup.Semifinal1.Winner, cup.Semifinal2.Winner, referees[rnd.Next(referees.Count - 1)]);
            }
            else if (Discipline == Disc.Dodgeball)
            {
                cup.Final = new DodgeballMatch(cup.Semifinal1.Winner, cup.Semifinal2.Winner, referees[rnd.Next(referees.Count - 1)]);
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
        public void reamoveReferee(Referee referee)
        {
            referees.Remove(referee);
        }
        public void printReferees()
        {

        }
    }
}

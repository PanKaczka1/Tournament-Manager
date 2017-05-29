using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    
namespace Tournament_Manager
{
    class Contest
    {
        protected SortedSet<Team> teams;
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
            teams = new SortedSet<Team>();
            referees = new List<Referee>();
            league = new League();
            cup = new Cup();
            this.discipline = discipline;
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

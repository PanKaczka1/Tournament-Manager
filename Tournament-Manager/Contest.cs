using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    enum Discipline { Volleyball, RopeDragging, Dogeball}
    class Contest
    {
        protected SortedSet<Team> teams;
        protected ArrayList referees;
        protected League league;
        protected Cup cup;
        public Contest (Discipline discipline)
        {

        }
        public void addTeam(Team team)
        {

        }
    }
}

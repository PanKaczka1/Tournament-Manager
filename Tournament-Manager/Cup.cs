using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class Cup : Stage
    {
        private Match semifinal1;
        private Match semifinal2;
        private Match final;

        public void generateSemifinals()
        {
            if(Discipline.get == Disc.Volleyball)
            {
                semifinal1 = new VolleyballMatch(team1, team2, referee1, referee2, referee3);
                semifinal2 = new VolleyballMatch(team1, team2, referee1, referee2, referee3);
            }
            if (Discipline.get == Disc.RopeDragging)
            {
                semifinal1 = new RopeDraggingMatch(team1, team2, referee);
                semifinal2 = new RopeDraggingMatch(team1, team2, referee);
            }
            if (Discipline.get == Disc.Dodgeball)
            {
                semifinal1 = new RopeDraggingMatch(team1, team2, referee);
                semifinal2 = new RopeDraggingMatch(team1, team2, referee);
            }
        }
        public void generateFinals()
        {
            if (Discipline.get == Disc.Volleyball)
            {
                final = new VolleyballMatch(team1, team2, referee1, referee2, referee3);
            }
            if (Discipline.get == Disc.RopeDragging)
            {
                final = new RopeDraggingMatch(team1, team2, referee);
            }
            if (Discipline.get == Disc.Dodgeball)
            {
                final = new RopeDraggingMatch(team1, team2, referee);
            }
        public override void printScores()
        {

        }
        public override void printSchedule()
        {

        }
    }
}

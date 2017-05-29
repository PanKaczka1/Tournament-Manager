using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    public class Team
    {
        private String name;
        private uint points;
        private uint matchesNo;

        public uint MatchesNo
        {
            get { return matchesNo; }
            set { matchesNo = value; }
        }

        public uint Points
        {
            get { return points; }
            set { points = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Team(String name)
        {
            this.name = name;
            points = 0;
            matchesNo = 0;
        }
    }
}

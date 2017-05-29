using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class Referee
    {
        private String name;
        private String surname;

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}

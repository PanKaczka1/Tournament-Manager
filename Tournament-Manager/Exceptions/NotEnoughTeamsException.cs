using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class NotEnoughTeamsException : Exception
    {
        public NotEnoughTeamsException(){}
        public NotEnoughTeamsException(string message): base(message){}
    }
}

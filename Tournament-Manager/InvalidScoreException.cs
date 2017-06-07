using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class InvalidScoreException : Exception
    {
        public InvalidScoreException()
        {

        }
        public InvalidScoreException(string message) : base(message)
        {

        }
    }
}

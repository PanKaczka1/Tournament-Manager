using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class InvalidRefereesException : Exception
    {
        public InvalidRefereesException()
        {

        }
        public InvalidRefereesException(string message):base(message)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Manager
{
    class NotEnoughRefereesException : Exception
    {
        public NotEnoughRefereesException()
        {

        }
        public NotEnoughRefereesException(string message) : base(message)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Tournament_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Tournament _tournament;

        public Tournament tournament
        {
            get { return _tournament; }
            set { _tournament = value; }
        }
    }
}

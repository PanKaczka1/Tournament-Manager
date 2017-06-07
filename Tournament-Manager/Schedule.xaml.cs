using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tournament_Manager
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        private Tournament tournament;
        public Schedule(Tournament t, Disc discipline)
        {
            DataContext = this;
            this.tournament = t;
            InitializeComponent();
            volleyballScheduleLV.ItemsSource = tournament.ContestVolleyball.League.Matches;

            switch (discipline)
            {
                case Disc.Volleyball:
                    
                    break;
                case Disc.Dodgeball:
                    
                    break;
                case Disc.RopeDragging:
                    
                    break;
            }
        }

    }
}

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
    /// Interaction logic for Referees.xaml
    /// </summary>
    public partial class Referees : Window
    {
        private Tournament tournament;

        public Referees(Tournament t, Disc discipline)
        {
            this.tournament = t;
            InitializeComponent();
            switch (discipline)
            {
                case Disc.Volleyball:                
                    RefereesList.ItemsSource = tournament.ContestVolleyball.Referees;
                    break;
                case Disc.Dodgeball:
                    RefereesList.ItemsSource = tournament.ContestDodgeball.Referees;
                    break;
                case Disc.RopeDragging:
                    RefereesList.ItemsSource = tournament.ContestRopeDragging.Referees;
                    break;
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

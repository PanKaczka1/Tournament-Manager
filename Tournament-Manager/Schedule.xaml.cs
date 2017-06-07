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
        private Disc discipline;
        public Schedule(Tournament t, Disc discipline)
        {
            DataContext = this;
            this.tournament = t;
            this.discipline = discipline;
            InitializeComponent();

            switch (this.discipline)
            {
                case Disc.Volleyball:
                    ScheduleLV.ItemsSource = tournament.ContestVolleyball.League.Matches;
                    break;
                case Disc.Dodgeball:
                    ScheduleLV.ItemsSource = tournament.ContestDodgeball.League.Matches;
                    break;
                case Disc.RopeDragging:
                    ScheduleLV.ItemsSource = tournament.ContestRopeDragging.League.Matches;
                    break;
            }
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            Match m = sender as Match;
            PlayMatchWindow pmw;
            switch(discipline)
            {
                case Disc.Volleyball:
                    pmw = new PlayMatchWindow(ScheduleLV.SelectedItem, Disc.Volleyball);
                    pmw.Show();
                    break;
                case Disc.Dodgeball:
                    pmw = new PlayMatchWindow(ScheduleLV.SelectedItem, Disc.Dodgeball);
                    pmw.Show();
                    break;
                case Disc.RopeDragging:
                    pmw = new PlayMatchWindow(ScheduleLV.SelectedItem, Disc.RopeDragging);
                    pmw.Show();
                    break;
            }

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ScheduleLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            playBtn.IsEnabled = true;
        }
    }
}

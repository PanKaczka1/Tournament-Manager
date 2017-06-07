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
                    MatchesLV.ItemsSource = tournament.ContestVolleyball.League.PlayedMatches;
                    ScheduleLabel.Content = "Siatkówka - rozgrywki ligowe";
                    break;
                case Disc.Dodgeball:
                    ScheduleLV.ItemsSource = tournament.ContestDodgeball.League.Matches;
                    MatchesLV.ItemsSource = tournament.ContestDodgeball.League.PlayedMatches;
                    ScheduleLabel.Content = "Dwa ognie - rozgrywki ligowe";
                    break;
                case Disc.RopeDragging:
                    ScheduleLV.ItemsSource = tournament.ContestRopeDragging.League.Matches;
                    MatchesLV.ItemsSource = tournament.ContestRopeDragging.League.PlayedMatches;
                    ScheduleLabel.Content = "Przeciąganie liny - rozgrywki ligowe";
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
                    pmw = new PlayMatchWindow(ScheduleLV.SelectedItem, Disc.Volleyball, tournament.ContestVolleyball.Referees);
                    if (pmw.ShowDialog() == true)
                    {
                        Match tmp = pmw.match;
                        tournament.ContestVolleyball.League.PlayedMatches.Add(tmp);
                        tournament.ContestVolleyball.League.Matches.Remove(tmp);
                    }
                    break;
                case Disc.Dodgeball:
                    pmw = new PlayMatchWindow(ScheduleLV.SelectedItem, Disc.Dodgeball, tournament.ContestDodgeball.Referees);
                    if (pmw.ShowDialog() == true)
                    {
                        Match tmp = pmw.match;
                        tournament.ContestDodgeball.League.PlayedMatches.Add(tmp);
                        tournament.ContestDodgeball.League.Matches.Remove(tmp);
                    }
                    break;
                case Disc.RopeDragging:
                    pmw = new PlayMatchWindow(ScheduleLV.SelectedItem, Disc.RopeDragging, tournament.ContestRopeDragging.Referees);
                    if (pmw.ShowDialog() == true)
                    {
                        Match tmp = pmw.match;
                        tournament.ContestRopeDragging.League.PlayedMatches.Add(tmp);
                        tournament.ContestRopeDragging.League.Matches.Remove(tmp);
                    }
                    break;
            }
            switch(discipline)
            {
                case Disc.Volleyball:
                    tournament.ContestVolleyball.generateCupStage();
                    if (tournament.ContestVolleyball.Cup.Semifinal1 != null)
                        ScheduleLabel.Content = "Siatkówka - rozgrywki pucharowe";
                    break;
                case Disc.RopeDragging:
                    tournament.ContestRopeDragging.generateCupStage();
                    if (tournament.ContestRopeDragging.Cup.Semifinal1 != null)
                        ScheduleLabel.Content = "Przeciąganie liny - rozgrywki pucharowe";
                    break;
                case Disc.Dodgeball:
                    tournament.ContestDodgeball.generateCupStage();
                    if (tournament.ContestDodgeball.Cup.Semifinal1 != null)
                        ScheduleLabel.Content = "Dwa ognie - rozgrywki pucharowe";
                    break;
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ScheduleLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScheduleLV.SelectedItem != null)
                playBtn.IsEnabled = true;
            else
                playBtn.IsEnabled = false;
        }
    }
}

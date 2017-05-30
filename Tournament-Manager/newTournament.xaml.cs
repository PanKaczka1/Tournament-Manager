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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tournament_Manager
{
    /// <summary>
    /// Interaction logic for newTournament.xaml
    /// </summary>
    public partial class newTournament : Page
    {
        private Tournament tournament;

        public newTournament(Tournament t)
        {
            tournament = t;
            InitializeComponent();

            volleyballTeamsLB.ItemsSource = tournament.ContestVolleyball.Teams;
            volleyballRefereesLB.ItemsSource = tournament.ContestVolleyball.Referees;

            dodgeballTeamsLB.ItemsSource = tournament.ContestDodgeball.Teams;
            dodgeballRefereesLB.ItemsSource = tournament.ContestDodgeball.Referees;

            ropeDraggingTeamsLB.ItemsSource = tournament.ContestRopeDragging.Teams;
            ropeDraggingTeamsLB.ItemsSource = tournament.ContestRopeDragging.Referees;
        }

        private void volleyballAddTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = volleyballTeamsTextBox.Text.Trim();
            if (trimmed != "")
            {
                Team t = new Team(volleyballTeamsTextBox.Text);
                tournament.ContestVolleyball.addTeam(t);
                volleyballTeamsTextBox.Text = "";
            }
        }

        private void volleyballRemoveTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestVolleyball.removeTeam((Team)volleyballTeamsLB.SelectedItem);    
        }

        private void volleyballAddRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = volleyballRefereesTextBox.Text.Trim();
            if (trimmed != "")
            {
                Referee r = new Referee(volleyballRefereesTextBox.Text);
                tournament.ContestVolleyball.addReferee(r);
                volleyballRefereesTextBox.Text = "";
            }
        }

        private void volleyballRemoveRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestVolleyball.removeReferee((Referee)volleyballRefereesLB.SelectedItem);
        }

    }
}

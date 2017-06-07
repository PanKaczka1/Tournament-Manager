using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PlayMatchWindow.xaml
    /// </summary>
    public partial class PlayMatchWindow : Window
    {
        public Match match { get; private set; }
        private ObservableCollection<Referee> referees;
        private Disc discipline;
        public PlayMatchWindow(Object match, Disc discipline, ObservableCollection<Referee> refs)
        {
            this.match = match as Match;
            this.discipline = discipline;
            this.referees = refs;
            InitializeComponent();
            FirstTeamLabel.Content = this.match.Team1.Name;
            SecondTeamLabel.Content = this.match.Team2.Name;

            FirstRefereeCB.ItemsSource = this.referees;
            FirstTeamScoresCB.Items.Add("0");
            FirstTeamScoresCB.Items.Add("1");

            SecondTeamScoresCB.Items.Add("0");
            SecondTeamScoresCB.Items.Add("1");
            if (discipline == Disc.Volleyball)
            {
                SecondRefereeCB.ItemsSource = refs;
                ThirdRefereeCB.ItemsSource = refs;
                FirstTeamScoresCB.Items.Add("2");
                FirstTeamScoresCB.Items.Add("3");

                SecondTeamScoresCB.Items.Add("2");
                SecondTeamScoresCB.Items.Add("3");
            } else
            {
                SecondRefereeCB.Visibility = Visibility.Hidden;
                ThirdRefereeCB.Visibility = Visibility.Hidden;
            }
        }

        public void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            switch(discipline)
            {
                case Disc.Volleyball:
                    Referee[] r = new Referee[3];
                    r[0] = FirstRefereeCB.SelectedItem as Referee;
                    r[1] = SecondRefereeCB.SelectedItem as Referee;
                    r[2] = ThirdRefereeCB.SelectedItem as Referee;
                    match = new VolleyballMatch(match.Team1, match.Team2,UInt32.Parse((string) FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), r);
                    match.Play();
                    break;
                case Disc.RopeDragging:
                    match = new RopeDraggingMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee);
                    match.Play();
                    break;
                case Disc.Dodgeball:
                    match = new DodgeballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee);
                    match.Play();
                    break;
            }
            this.DialogResult = true;
        }


    }
}

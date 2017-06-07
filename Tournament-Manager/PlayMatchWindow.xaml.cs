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
    /// Interaction logic for PlayMatchWindow.xaml
    /// </summary>
    public partial class PlayMatchWindow : Window
    {
        private Match match;
        public PlayMatchWindow(Object match, Disc discipline)
        {
            this.match = match as Match;
            InitializeComponent();
            FirstTeamLabel.Content = this.match.Team1.Name;
            SecondTeamLabel.Content = this.match.Team2.Name;

            FirstTeamScoresCB.Items.Add("0");
            FirstTeamScoresCB.Items.Add("1");

            SecondTeamScoresCB.Items.Add("0");
            SecondTeamScoresCB.Items.Add("1");
            if (discipline == Disc.Volleyball)
            {
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
    }
}

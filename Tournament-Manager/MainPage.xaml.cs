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
using System.IO;
using Microsoft.Win32;

namespace Tournament_Manager
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Tournament tournament;
        public MainPage(Tournament t)
        {
            this.tournament = t;
            InitializeComponent();
            ScoresLV.ItemsSource = tournament.ContestVolleyball.Teams;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void scheduleBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void teamsBtn_Click(object sender, RoutedEventArgs e)
        {
            Teams t = new Teams(tournament);
            t.Show();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void newTournamentBtn_Click(object sender, RoutedEventArgs e)
        {
            newTournament nt = new newTournament();
            NavigationService.Navigate(nt);
        }

        private void loadTournamentBtn_Click(object sender, RoutedEventArgs e)
        {
            Tournament tournament = new Tournament();
            loadTournament lt = new loadTournament();
            NavigationService.Navigate(lt);
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

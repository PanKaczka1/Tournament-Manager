using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void newTournamentBtn_Click(object sender, RoutedEventArgs e)
        {
            Tournament tournament = new Tournament();
            NewTournament nt = new NewTournament(tournament);
            NavigationService.Navigate(nt);
        }

        private void loadTournamentBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) 
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                Tournament t = (Tournament)bf.Deserialize(fs);
                fs.Close();
                MainPage mp = new MainPage(t);
                NavigationService.Navigate(mp);
            }

        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

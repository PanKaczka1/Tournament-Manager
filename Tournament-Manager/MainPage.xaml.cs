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
using System.Runtime.Serialization.Formatters.Binary;

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
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "xD.dat";
            if (savefile.ShowDialog() == true)
            {
                FileStream fs = new FileStream(savefile.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, tournament);
                fs.Close();
            }
        }

        private void volleyballScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            Schedule s = new Schedule(tournament, Disc.Volleyball);
            s.Show();
        }

        private void volleyballTeamsBtn_Click(object sender, RoutedEventArgs e)
        {
            Teams t = new Teams(tournament, Disc.Volleyball);
            t.Show();
        }
       
        private void volleyballRefereesBtn_Click(object sender, RoutedEventArgs e)
        {
            Referees r = new Referees(tournament, Disc.Volleyball);
            r.Show();
        }
    }
}

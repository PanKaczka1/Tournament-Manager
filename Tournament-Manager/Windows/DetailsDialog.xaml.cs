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
    /// Interaction logic for DetailsDialog.xaml
    /// </summary>
    public partial class DetailsDialog : Window
    {
        public DetailsDialog(Match match, Disc discipline)
        {
            InitializeComponent();
            switch (discipline)
            {
                case Disc.Volleyball:
                    Referee1Name.Content = match.referees[0].FullName;
                    Referee2Name.Content = match.referees[1].FullName;
                    Referee3Name.Content = match.referees[2].FullName;
                    break;
                default:
                    Referee1Name.Content = match.referees[0].FullName;

                    Referee2Label.Visibility = Visibility.Hidden;
                    Referee2Name.Visibility = Visibility.Hidden;

                    Referee3Label.Visibility = Visibility.Hidden;
                    Referee3Name.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

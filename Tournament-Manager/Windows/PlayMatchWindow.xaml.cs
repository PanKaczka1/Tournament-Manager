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
                    try
                    {
                        AreScoresGood(Disc.Volleyball);
                        AreRefereesGood(Disc.Volleyball);
                    }
                    catch (InvalidScoreException ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    catch (InvalidRefereesException ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Referee[] r = new Referee[3];
                    r[0] = FirstRefereeCB.SelectedItem as Referee;
                    r[1] = SecondRefereeCB.SelectedItem as Referee;
                    r[2] = ThirdRefereeCB.SelectedItem as Referee;

                    switch (match.Description)
                    {
                        case "Półfinał":
                            match = new VolleyballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), r, "Półfinał");
                            match.PlayCup();
                            break;
                        case null:
                            match = new VolleyballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), r, "");
                            match.Play();
                            break;
                        case "Finał":
                            match = new VolleyballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), r, "Finał");
                            match.PlayCup();
                            break;
                    }
                    break;
                case Disc.RopeDragging:
                    try
                    {
                        AreScoresGood(Disc.RopeDragging);
                        AreRefereesGood(Disc.RopeDragging);
                    }
                    catch (InvalidScoreException ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    catch (InvalidRefereesException ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    switch (match.Description)
                    {
                        case "Półfinał":
                            match = new RopeDraggingMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee, "Półfinał");
                            match.PlayCup();
                            break;
                        case null:
                            match = new RopeDraggingMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee, "");
                            match.Play();
                            break;
                        case "Finał":
                            match = new RopeDraggingMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee, "Finał");
                            match.PlayCup();
                            break;
                    }
                    break;
                case Disc.Dodgeball:
                    try
                    {
                        AreScoresGood(Disc.Dodgeball);
                        AreRefereesGood(Disc.Dodgeball);
                    }
                    catch (InvalidScoreException ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    catch (InvalidRefereesException ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    switch (match.Description)
                    {
                        case "Półfinał":
                            match = new DodgeballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee, "Półfinał");
                            match.PlayCup();
                            break;
                        case null:
                            match = new DodgeballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee, "");
                            match.Play();
                            break;
                        case "Finał":
                            match = new DodgeballMatch(match.Team1, match.Team2, UInt32.Parse((string)FirstTeamScoresCB.SelectedItem), UInt32.Parse((string)SecondTeamScoresCB.SelectedItem), FirstRefereeCB.SelectedItem as Referee, "Finał");
                            match.PlayCup();
                            break;
                    }
                    break;
            }
            this.DialogResult = true;
        }

        private void FirstTeamScoresCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((string)SecondTeamScoresCB.SelectedItem == "3" && (string)FirstTeamScoresCB.SelectedItem == "3")
                {
                    throw new InvalidScoreException("Błędny wynik");
                }
            }
            catch (InvalidScoreException ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                FirstTeamScoresCB.SelectedItem = FirstTeamScoresCB.Items[0];
            }
        }

        private void SecondTeamScoresCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((string)FirstTeamScoresCB.SelectedItem == "3" && (string)SecondTeamScoresCB.SelectedItem == "3")
                {
                    throw new InvalidScoreException("Błędny wynik");
                }
            }
            catch (InvalidScoreException ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                SecondTeamScoresCB.SelectedItem = SecondTeamScoresCB.Items[0];
            }
        }

        private void AreScoresGood(Disc discipline)
        {
            switch (discipline)
            {
                case Disc.Volleyball:
                    if (!((string)FirstTeamScoresCB.SelectedItem == "3" || (string)SecondTeamScoresCB.SelectedItem == "3"))
                            throw new InvalidScoreException("Błędny wynik");
                    break;
                default:
                    if (Int32.Parse((string)FirstTeamScoresCB.SelectedItem) + Int32.Parse((string)SecondTeamScoresCB.SelectedItem) != 1)
                        throw new InvalidScoreException("Błędny wynik");
                    break;
            }
        }

        private void AreRefereesGood(Disc discipline)
        {
            switch (discipline)
            {
                case Disc.Volleyball:
                    if (FirstRefereeCB.SelectedItem == null || SecondRefereeCB.SelectedItem == null || ThirdRefereeCB.SelectedItem == null)
                        throw new InvalidRefereesException("Nie podano wszystkich sędziów");
                    if (FirstRefereeCB.SelectedItem == SecondRefereeCB.SelectedItem || FirstRefereeCB.SelectedItem == ThirdRefereeCB.SelectedItem || SecondRefereeCB.SelectedItem == ThirdRefereeCB.SelectedItem)
                        throw new InvalidRefereesException("Sędziowie nie mogą się powtarzać");
                    break;
                default:
                    if (FirstRefereeCB.SelectedItem == null)
                        throw new InvalidRefereesException("Nie podano sędziego");
                    break;
            }
        }
       
    }
}

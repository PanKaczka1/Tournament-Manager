﻿using System;
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
    public partial class NewTournament : Page
    {
        private Tournament tournament;

        public NewTournament(Tournament t)
        {
            tournament = t;
            InitializeComponent();
            volleyballTeamsLeftLabel.Content = tournament.ContestVolleyball.TeamsAmount - tournament.ContestVolleyball.Teams.Count();
            dodgeballTeamsLeftLabel.Content = tournament.ContestDodgeball.TeamsAmount - tournament.ContestDodgeball.Teams.Count();
            ropeDraggingTeamsLeftLabel.Content = tournament.ContestRopeDragging.TeamsAmount - tournament.ContestRopeDragging.Teams.Count();

            tournament.ContestVolleyball.TeamsAmount = (uint)volleyballSlider.Value;
            tournament.ContestDodgeball.TeamsAmount = (uint)dodgeballSlider.Value;
            tournament.ContestRopeDragging.TeamsAmount = (uint)ropeDraggingSlider.Value;

            volleyballTeamsLB.ItemsSource = tournament.ContestVolleyball.Teams;
            volleyballRefereesLB.ItemsSource = tournament.ContestVolleyball.Referees;

            dodgeballTeamsLB.ItemsSource = tournament.ContestDodgeball.Teams;
            dodgeballRefereesLB.ItemsSource = tournament.ContestDodgeball.Referees;

            ropeDraggingTeamsLB.ItemsSource = tournament.ContestRopeDragging.Teams;
            ropeDraggingRefereesLB.ItemsSource = tournament.ContestRopeDragging.Referees;
        }

        private void volleyballAddTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = volleyballTeamsTextBox.Text.Trim();
            if (trimmed != "" && tournament.ContestVolleyball.Teams.Count() < tournament.ContestVolleyball.TeamsAmount)
            {
                Team t = new Team(volleyballTeamsTextBox.Text);
                try
                {
                    foreach(Team o in tournament.ContestVolleyball.Teams)
                        if (o.Name.Equals(t.Name))
                            throw new ArgumentException("Nazwy drużyn nie mogą się powtarzać");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                tournament.ContestVolleyball.addTeam(t);
                volleyballTeamsLeftLabel.Content = tournament.ContestVolleyball.TeamsAmount - tournament.ContestVolleyball.Teams.Count();
                volleyballTeamsTextBox.Text = "";
            }
        }

        private void volleyballRemoveTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestVolleyball.removeTeam((Team)volleyballTeamsLB.SelectedItem);
            volleyballTeamsLeftLabel.Content = tournament.ContestVolleyball.TeamsAmount - tournament.ContestVolleyball.Teams.Count();
        }

        private void volleyballAddRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = volleyballRefereesTextBox.Text.Trim();
            if (trimmed != "")
            {
                try
                {
                    Referee r = new Referee(volleyballRefereesTextBox.Text);
                    foreach (Referee o in tournament.ContestVolleyball.Referees)
                        if (o.Name.Equals(r.Name) && o.Surname.Equals(r.Surname))
                            throw new ArgumentException("W systemie już istnieje sędzia o podanych danych");
                    tournament.ContestVolleyball.addReferee(r);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                volleyballRefereesTextBox.Text = "";
            }
        }

        private void volleyballRemoveRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestVolleyball.removeReferee((Referee)volleyballRefereesLB.SelectedItem);
        }

        private void volleyballSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tournament.ContestVolleyball.TeamsAmount = (uint)volleyballSlider.Value;
            while (tournament.ContestVolleyball.Teams.Count > tournament.ContestVolleyball.TeamsAmount)
                tournament.ContestVolleyball.Teams.RemoveAt(tournament.ContestVolleyball.Teams.Count - 1);

            if (volleyballTeamsLeftLabel != null)
                volleyballTeamsLeftLabel.Content = tournament.ContestVolleyball.TeamsAmount - tournament.ContestVolleyball.Teams.Count();
        }

        private void volleyballRefereesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.A) || (e.Key > Key.Z))
                e.Handled = true;
        }

        private void dodgeballAddTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = dodgeballTeamsTextBox.Text.Trim();
            if (trimmed != "" && tournament.ContestDodgeball.Teams.Count() < tournament.ContestDodgeball.TeamsAmount)
            {
                Team t = new Team(dodgeballTeamsTextBox.Text);
                foreach (Team o in tournament.ContestDodgeball.Teams)
                    if (o.Name.Equals(t.Name))
                        throw new NotImplementedException();

                tournament.ContestDodgeball.addTeam(t);
                dodgeballTeamsLeftLabel.Content = tournament.ContestDodgeball.TeamsAmount - tournament.ContestDodgeball.Teams.Count();
                dodgeballTeamsTextBox.Text = "";
            }
        }

        private void dodgeballRemoveTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestDodgeball.removeTeam((Team)dodgeballTeamsLB.SelectedItem);
            dodgeballTeamsLeftLabel.Content = tournament.ContestDodgeball.TeamsAmount - tournament.ContestDodgeball.Teams.Count();
        }

        private void dodgeballAddRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = dodgeballRefereesTextBox.Text.Trim();
            if (trimmed != "")
            {
                Referee r = new Referee(dodgeballRefereesTextBox.Text);
                foreach (Referee o in tournament.ContestDodgeball.Referees)
                    if (o.Name.Equals(r.Name) && o.Surname.Equals(r.Surname))
                        throw new NotImplementedException();

                tournament.ContestDodgeball.addReferee(r);
                dodgeballRefereesTextBox.Text = "";
            }
        }

        private void dodgeballRemoveRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestDodgeball.removeReferee((Referee)dodgeballRefereesLB.SelectedItem);
        }

        private void dodgeballSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tournament.ContestDodgeball.TeamsAmount = (uint)dodgeballSlider.Value;
            while (tournament.ContestDodgeball.Teams.Count > tournament.ContestDodgeball.TeamsAmount)
                tournament.ContestDodgeball.Teams.RemoveAt(tournament.ContestDodgeball.Teams.Count - 1);

            if (dodgeballTeamsLeftLabel != null)
                dodgeballTeamsLeftLabel.Content = tournament.ContestDodgeball.TeamsAmount - tournament.ContestDodgeball.Teams.Count();
        }

        private void dodgeballRefereesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.A) || (e.Key > Key.Z))
                e.Handled = true;
        }

        private void ropeDraggingAddTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = ropeDraggingTeamsTextBox.Text.Trim();
            if (trimmed != "" && tournament.ContestRopeDragging.Teams.Count() < tournament.ContestRopeDragging.TeamsAmount)
            {
                Team t = new Team(ropeDraggingTeamsTextBox.Text);
                foreach (Team o in tournament.ContestRopeDragging.Teams)
                    if (o.Name.Equals(t.Name))
                        throw new NotImplementedException();

                tournament.ContestRopeDragging.addTeam(t);
                ropeDraggingTeamsLeftLabel.Content = tournament.ContestRopeDragging.TeamsAmount - tournament.ContestRopeDragging.Teams.Count();
                ropeDraggingTeamsTextBox.Text = "";
            }
        }

        private void ropeDraggingRemoveTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestRopeDragging.removeTeam((Team)ropeDraggingTeamsLB.SelectedItem);
            ropeDraggingTeamsLeftLabel.Content = tournament.ContestRopeDragging.TeamsAmount - tournament.ContestRopeDragging.Teams.Count();
        }

        private void ropeDraggingAddRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            String trimmed = ropeDraggingRefereesTextBox.Text.Trim();
            if (trimmed != "")
            {
                Referee r = new Referee(ropeDraggingRefereesTextBox.Text);
                foreach (Referee o in tournament.ContestRopeDragging.Referees)
                    if (o.Name.Equals(r.Name) && o.Surname.Equals(r.Surname))
                        throw new NotImplementedException();

                tournament.ContestRopeDragging.addReferee(r);
                ropeDraggingRefereesTextBox.Text = "";
            }
        }

        private void ropeDraggingRemoveRefereeBtn_Click(object sender, RoutedEventArgs e)
        {
            tournament.ContestRopeDragging.removeReferee((Referee)ropeDraggingRefereesLB.SelectedItem);
        }

        private void ropeDraggingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tournament.ContestRopeDragging.TeamsAmount = (uint)ropeDraggingSlider.Value;
            while (tournament.ContestRopeDragging.Teams.Count > tournament.ContestRopeDragging.TeamsAmount)
                tournament.ContestRopeDragging.Teams.RemoveAt(tournament.ContestRopeDragging.Teams.Count - 1);

            if (ropeDraggingTeamsLeftLabel != null)
                ropeDraggingTeamsLeftLabel.Content = tournament.ContestRopeDragging.TeamsAmount - tournament.ContestRopeDragging.Teams.Count();
        }

        private void ropeDraggingRefereesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.A) || (e.Key > Key.Z))
                e.Handled = true;
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            for (int i = 0; i < tournament.ContestVolleyball.Teams.Count - 1; i++)
            {
                for (int j = i + 1; j < tournament.ContestVolleyball.Teams.Count; j++)
                {
                    VolleyballMatch vm = new VolleyballMatch(tournament.ContestVolleyball.Teams[i], tournament.ContestVolleyball.Teams[j]);
                    tournament.ContestVolleyball.League.Matches.Add(vm);
                }
            }
            for (int i = 0; i < tournament.ContestRopeDragging.Teams.Count - 1; i++)
            {
                for (int j = i + 1; j < tournament.ContestRopeDragging.Teams.Count; j++)
                {
                    RopeDraggingMatch rm = new RopeDraggingMatch(tournament.ContestRopeDragging.Teams[i], tournament.ContestRopeDragging.Teams[j]);
                    tournament.ContestRopeDragging.League.Matches.Add(rm);
                }
            }
            for (int i = 0; i < tournament.ContestDodgeball.Teams.Count - 1; i++)
            {
                for (int j = i + 1; j < tournament.ContestDodgeball.Teams.Count; j++)
                {
                    DodgeballMatch dm = new DodgeballMatch(tournament.ContestDodgeball.Teams[i], tournament.ContestDodgeball.Teams[j]);
                    tournament.ContestDodgeball.League.Matches.Add(dm);
                }
            }
            MainPage mp = new MainPage(tournament);
            NavigationService.Navigate(mp);

        }

        private void CheckInputs()
        {
            if (tournament.ContestVolleyball.Teams.Count < tournament.ContestVolleyball.TeamsAmount)
                throw new NotEnoughTeamsException("Siatkówka - podano za mało drużyn");
            if (tournament.ContestVolleyball.Referees.Count() < 3)
                throw new NotEnoughRefereesException("Siatkówka - podano za mało sędziów");

            if (tournament.ContestDodgeball.Teams.Count < tournament.ContestDodgeball.TeamsAmount)
                throw new NotEnoughTeamsException("Dwa ognie - podano za mało drużyn");
            if (tournament.ContestDodgeball.Referees.Count() < 1)
                throw new NotImplementedException("Dwa ognie - podano za mało sędziów");

            if (tournament.ContestRopeDragging.Teams.Count < tournament.ContestRopeDragging.TeamsAmount)
                throw new NotEnoughTeamsException("Przeciąganie liny - podano za mało drużyn");
            if (tournament.ContestRopeDragging.Referees.Count() < 1)
                throw new NotImplementedException("Przeciąganie liny - podano za mało sędziów");
        }
    }
}

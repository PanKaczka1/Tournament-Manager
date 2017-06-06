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
using System.Collections.ObjectModel;

namespace Tournament_Manager
{
    /// <summary>
    /// Interaction logic for Teams.xaml
    /// </summary>
    public partial class Teams : Window
    {
        private Tournament tournament;
        public Teams(Tournament tournament)
        {
            this.tournament = tournament;
            InitializeComponent();
            ObservableCollection<Team> sortedTeams = new ObservableCollection<Team>(tournament.ContestVolleyball.Teams.OrderBy(Team => Team.Points));
            TeamsList.ItemsSource = sortedTeams;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

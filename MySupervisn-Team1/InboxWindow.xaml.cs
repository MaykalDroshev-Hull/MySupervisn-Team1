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
using System.Windows.Shapes;

namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class InboxWindow : Window
    {
        public InboxWindow()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            StudentDashboard studentDashboardWindow = new StudentDashboard();
            studentDashboardWindow.Show();
        }
    }
}
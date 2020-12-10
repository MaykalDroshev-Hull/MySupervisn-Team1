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

namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for StudentSearch.xaml
    /// </summary>
    public partial class StudentSearch : Window
    {
        private StaffDashboard Dashboard { get; set; }
        public StudentSearch(StaffDashboard dashboard)
        {
            Dashboard = dashboard;
            InitializeComponent();
        }

        private void ReturnToDashboard_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Dashboard.Show();
        }
    }
}

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
    /// Interaction logic for StudentHub.xaml
    /// </summary>
    public partial class StaffDashboard : Window
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }

        public StaffDashboard(Staff staff)
        {
            switch (staff.Role)
            {
                case "Student Hub":
                    // Make student hub elements visible
                    break;
                case "Personal Supervisor":
                    // Make personal supervisor hub elements visible
                    break;
                case "Director of Study":
                    // Make director of study hub elements visible
                    break;
            }
        }
        private void GenerateOverview_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

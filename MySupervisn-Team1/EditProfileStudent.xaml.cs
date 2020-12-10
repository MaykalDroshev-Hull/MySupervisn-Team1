using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace MySupervisn_Team1
{
    public partial class EditProfileStudent : Window
    {
        public EditProfileStudent()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            StudentDashboard studentDashboardWindow = new StudentDashboard();
            studentDashboardWindow.Show();
        }
    }
}

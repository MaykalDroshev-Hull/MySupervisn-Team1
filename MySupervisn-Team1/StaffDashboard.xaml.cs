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
            InitializeComponent();
            StaffName.Content = "Name: " + staff.Name;
            StaffRole.Content = "Role: " + staff.Role;
            switch (staff.Role)
            {
                case "Student Hub":
                    ShowStudentHubControls();
                    break;
                case "Personal Supervisor":
                    ShowSupervisorControls();
                    break;
                case "Director of Study":
                    ShowDirectorControls();
                    break;
            }
        }

        private void ShowStudentHubControls()
        {

        }

        private void ShowSupervisorControls()
        {
            AddDeleteUsers.Visibility = Visibility.Hidden;
            CreateMeeting.Visibility = Visibility.Visible;
        }

        private void ShowDirectorControls()
        {
            AddDeleteUsers.Visibility = Visibility.Hidden;
            GenerateOverview.Visibility = Visibility.Visible;
        }
        private void GenerateOverview_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddDelete_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AddUserWindow userWindow = new AddUserWindow();
            userWindow.Show();
        }

        private void Inbox_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Inbox inbox = new Inbox();
            inbox.Show();
        }

        private void CreateMeeting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchStudent_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            StudentSearch studentSearch = new StudentSearch(this);
            studentSearch.Show();
        }
    }
}

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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void Inbox_Click(object sender, RoutedEventArgs e)
        {
            Close();
            InboxWindow inboxWindow = new InboxWindow();
            inboxWindow.Show();
        }

        private void EditProfileStudent_Click(object sender, RoutedEventArgs e)
        {
            Close();
            EditProfileStudent editProfileStudentWindow = new EditProfileStudent();
            editProfileStudentWindow.Show();
        }

        private void Enquire_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Enquire enquireWindow = new Enquire();
            enquireWindow.Show();
        }

        private void LectureCheckIn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LectureCheckIn lectureCheckInWindow = new LectureCheckIn();
            lectureCheckInWindow.Show();
        }

        private void BookMeeting_Click(object sender, RoutedEventArgs e)
        {
            Close();
            BookMeeting bookMeetingWindow = new BookMeeting();
            bookMeetingWindow.Show();
        }
        private void Canvas_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://canvas.hull.ac.uk/");
        }
    }
}

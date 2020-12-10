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
using System.Data.SqlClient;

namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        string mUsername;

        public StudentDashboard()
        {
            InitializeComponent();

            //FromDatabase();
            //module_1.Content = mUsername;
        }

        public StudentDashboard(Student student)
        {

        }

        // WORK IN PROGRESS!!
        private string FromDatabase()
        {
            SqlConnection connection = new SqlConnection();
            var path = Environment.CurrentDirectory + @"\DataBase\Users.mdf";
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            connection.Open();

            SqlCommand search = new SqlCommand();
            search.CommandText = "select User_Id, Module1, Module2, Module3, from [Table]";
            search.Connection = connection;
            SqlDataReader reader = search.ExecuteReader();

            return reader.ToString();
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

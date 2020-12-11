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
        Student student1;
       

        public StudentDashboard()
        {
            //FromDatabase();
            //module_1.Content = mUsername;
        }

        public StudentDashboard(Student student)
        { 
            InitializeComponent();
            student1 = student;
            Name.Content = "Student Name: " + student.Name.ToString()+"       ID number:"+student1.IdNumber;
            int counter = 1;
            if (student.mMessages[0].Body != null)//It displays only 1 message
            {
                Messages.Items.Add(counter+". "+ student.mMessages[0].Subject + " \n " + student.mMessages[0].Body);
                counter++;
            }
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
            Inbox inboxWindow = new Inbox();
            inboxWindow.Show();
        }

        public void EditProfileStudent_Click(object sender, RoutedEventArgs e)
        {
            Close();
            EditProfileStudent editProfileStudentWindow = new EditProfileStudent(student1);
            editProfileStudentWindow.Show();
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

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditProfileStudent_Click(sender, e);
        }
    }
}

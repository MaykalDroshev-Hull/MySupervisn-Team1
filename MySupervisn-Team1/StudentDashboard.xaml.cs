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
        Student mStudent;
       
        public StudentDashboard(Student pStudent)
        { 
            InitializeComponent();
            mStudent = pStudent;
            Name.Content = "Student Name: " + pStudent.Name.ToString()+"       ID number:"+ mStudent.IdNumber;
            int counter = 1;
            if (pStudent.mMessages[0].Body != null)//It displays only 1 message
            {
                Messages.Items.Add(counter+". "+ pStudent.mMessages[0].Subject + " \n " + pStudent.mMessages[0].Body);
                counter++;
            }
            else
            {
                Messages.Items.Add("No messages");
            }
        }     
     

        private void Inbox_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Inbox inboxWindow = new Inbox(mStudent,mStudent.mMessages);
            inboxWindow.Show();
        }

        public void EditProfileStudent_Click(object sender, RoutedEventArgs e)
        {
            Close();
            EditProfileStudent editProfileStudentWindow = new EditProfileStudent(mStudent);
            editProfileStudentWindow.Show();
        }

       

        private void LectureCheckIn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LectureCheckIn lectureCheckInWindow = new LectureCheckIn(mStudent);
            lectureCheckInWindow.Show();
        }

        private void BookMeeting_Click(object sender, RoutedEventArgs e)
        {
            Close();
            BookMeeting bookMeetingWindow = new BookMeeting(mStudent);
            bookMeetingWindow.Show();
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

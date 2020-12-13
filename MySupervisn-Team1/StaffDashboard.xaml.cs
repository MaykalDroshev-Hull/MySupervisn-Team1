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
using System.IO;
using System.Data.SqlClient;
namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for StudentHub.xaml
    /// </summary>
    public partial class StaffDashboard : Window
    {
        private Staff mStaff;
        public List<Message> messages1 { get; set; }

        public StaffDashboard()
        {
            InitializeComponent();
        }

        public StaffDashboard(Staff pStaff,List<Message> messages)
        { 
            InitializeComponent();
            messages1 = messages;
            MessageInbox.Items.Add("1." + messages[0].Subject + " \n " + messages[0].Body);
            mStaff = pStaff;

           
            StaffName.Content = "Name: " + pStaff.Name;
            StaffRole.Content = "Role: " + pStaff.Role;
            switch (mStaff.Role)
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
            if (File.Exists("Report.txt")) { File.Delete("Report.txt"); }
            using (FileStream fileStream = new FileStream("Report.txt",FileMode.Create))
            {
              
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine($"Student Report. Created at {DateTime.Now}");

                    SqlConnection connection = DatabaseManager.CreateConnectionToDatabase();
                    
                    connection.Open();

                    SqlCommand search = new SqlCommand();
                    search.CommandText = " select Classification, FirstName, LastName, email, Supervisor from[Users_] where Classification!='Director of Study'";
                    search.Connection = connection;
                    SqlDataReader reader = search.ExecuteReader();

                    while (reader.Read())
                    {
                        writer.WriteLine($"Classification: {reader[0]} Name: {reader[1]} {reader[2]} Email: {reader[3]} Supervisor: {reader[4]}");
                    }
                    writer.WriteLine("End of Document");

                }
            }
            MessageBox.Show("Report Generated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddDelete_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
            AddDeleteUserWindow userWindow = new AddDeleteUserWindow();
            userWindow.Show();
        }

        private void Inbox_Click(object sender, RoutedEventArgs e)
        {
           

            Inbox inbox = new Inbox(mStaff,messages1);
            inbox.Show();
        }

        private void CreateMeeting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchStudent_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            StudentSearch studentSearch = new StudentSearch(this,mStaff);
            studentSearch.Show();
        }
        public void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Inbox_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            Inbox inboxWindow = new Inbox(mStaff,messages1);
            inboxWindow.Show();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            EditProfileStudent editProfile = new EditProfileStudent(mStaff);
            editProfile.Show();
        }
    }
}

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
        public StaffDashboard(Staff pStaff)
        {
           
            MessageInbox.Items.Add("1." + messages1[0].Subject + " \n " + messages1[0].Body);//not the best solution
            mStaff = pStaff;

            InitializeComponent();
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
            using (FileStream fileStream = new FileStream("report.txt",FileMode.CreateNew))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("Student Report");

                    SqlConnection connection = new SqlConnection();
                    var path = Environment.CurrentDirectory + @"\DataBase\Users.mdf";
                    connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
                    connection.Open();

                    SqlCommand search = new SqlCommand();
                    search.CommandText = " select User_Id, password, Classification, FirstName, LastName, email, password, Supervisor from[Users_]";
                    search.Connection = connection;
                    SqlDataReader reader = search.ExecuteReader();

                    while (reader.Read())
                    {
                        writer.WriteLine($"Id={reader[0]} password={reader[1]} classification={reader[2]} Name={reader[3]} {reader[4]} Email:{reader[5]} Supervisor:{reader[7]}");
                    }
                    writer.WriteLine("End of Document");

                }
            }
        }

        private void AddDelete_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            //AddUserWindow userWindow = new AddUserWindow();
            AddDeleteUserWindow userWindow = new AddDeleteUserWindow();
            userWindow.Show();
        }

        private void Inbox_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            Inbox inbox = new Inbox(mStaff);
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
        public void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}

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
using Microsoft.Win32;
namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for StudentHub.xaml
    /// </summary>
    public partial class StaffDashboard : Window
    {
        private Staff mStaff;

        private PersonalSupervisor mPersonalSupervisor;
        private DirectorOfStudy mDirectorOfStudy;
        private StudentHub mStudentHub;
        public List<Message> messages1 { get; set; }

        
        public StaffDashboard(PersonalSupervisor pPersonalSupervisor)
        {
            InitializeComponent();

            mPersonalSupervisor = pPersonalSupervisor;
            ShowSupervisorControls();
        }
        public StaffDashboard(DirectorOfStudy pDirectorOfStudy)
        {
            InitializeComponent();

            mDirectorOfStudy = pDirectorOfStudy;
            ShowDirectorControls();
        }
        public StaffDashboard(StudentHub pStudentHub)
        {
            InitializeComponent();

            mStudentHub = pStudentHub;
            ShowStudentHubControls();
        }
        public StaffDashboard(Staff pStaff, List<Message> messages)
        { 
            InitializeComponent();
            messages1 = messages;
            if (messages[0].Subject != string.Empty)
            {
                MessageInbox.Items.Add(messages[0].Subject + " \n " + messages[0].Body + "from" + messages[0].Sender);
            }
            else { MessageInbox.Items.Add("No messages"); }
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
        private void DataWindow_Closing(object sender, EventArgs e)
        {
            Environment.Exit(1);
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
            
            string report = "";
         
                    report+=($"Student Report. Created at {DateTime.Now}\n");

                    SqlConnection connection = DatabaseManager.CreateConnectionToDatabase();
                    
                    connection.Open();

                    SqlCommand search = new SqlCommand();
                    search.CommandText = " select Classification, FirstName, LastName, email, Supervisor from[Users_] where Classification!='Director of Study'";
                    search.Connection = connection;
                    SqlDataReader reader = search.ExecuteReader();

                    while (reader.Read())
                    {
                        report+=($"Classification: {reader[0]} Name: {reader[1]} {reader[2]} Email: {reader[3]} Supervisor: {reader[4]}\n");
                    }
                    report+=("End of Document\n");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, report);
                MessageBox.Show("Report Generated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
           
        private void AddDelete_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AddDeleteUserWindow addDeleteWindow = new AddDeleteUserWindow(this);
            addDeleteWindow.Show();
        }

        private void Inbox_Click(object sender, RoutedEventArgs e)
        {
            Inbox inbox = new Inbox(mStaff,messages1);
            inbox.Show();
        }

        private void CreateMeeting_Click(object sender, RoutedEventArgs e)
        {
            BookMeeting bookMeeting = new BookMeeting(mStaff);
            bookMeeting.Show();
        }

        private void SearchStudent_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            StudentSearch studentSearch = new StudentSearch(this,mStaff);
            studentSearch.Show();
        }
        public void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Inbox_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            Inbox inboxWindow = new Inbox(mStaff,messages1);
            inboxWindow.Show();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            EditProfileStudent editProfile = new EditProfileStudent(mStaff);
            editProfile.Show();
        }
    }
}

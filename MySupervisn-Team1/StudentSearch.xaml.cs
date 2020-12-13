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
using System.Windows.Forms;
using System.Configuration;

namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for StudentSearch.xaml
    /// </summary>
    public partial class StudentSearch : Window
    {
        private SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();
        private StaffDashboard Dashboard { get; set; }
        public StudentSearch(StaffDashboard dashboard)
        {
            Dashboard = dashboard;
            InitializeComponent();

            ShowAll();
           
        }

        private void ReturnToDashboard_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Dashboard.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SendMessage.IsEnabled = true;
            ViewProfile.IsEnabled = true;
            CreateMeeting.IsEnabled = true;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == string.Empty)
            {
                ShowAll();
                SendMessage.IsEnabled = false;
                ViewProfile.IsEnabled = false;
                CreateMeeting.IsEnabled = false;
            }
            else
            {
                mConnection.Close();
                mConnection.Open();
                SqlCommand search = new SqlCommand();

                search.CommandText = "select User_Id, Classification, FirstName, LastName,email,Supervisor from [Users_] where Classification='Student' and FirstName=@name";
                search.Parameters.AddWithValue("@name", Name.Text);
                search.Connection = mConnection;
                SqlDataReader reader = search.ExecuteReader();

                Students.ItemsSource = reader;
            }
        }
        private void ShowAll()
        {
            mConnection.Close();
            mConnection.Open();
            SqlCommand search = new SqlCommand();

            search.CommandText = "select User_Id, Classification, FirstName, LastName,email,Supervisor from [Users_] where Classification='Student'";
            search.Connection = mConnection;
            SqlDataReader reader = search.ExecuteReader();

            Students.ItemsSource = reader;
        }
    }
}

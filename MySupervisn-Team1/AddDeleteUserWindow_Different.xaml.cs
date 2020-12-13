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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddDeleteUserWindow : Window
    {
        private SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();

        private int mId;
        private string mName;
        private string mEmail;

        public AddDeleteUserWindow()
        { 
           
            InitializeComponent();
                    
            SqlCommand supervisors_ = new SqlCommand();
            supervisors_.CommandText = "select FirstName, LastName from [Users_] where Classification='Personal Supervisor';";
            supervisors_.Connection = mConnection;
            mConnection.Open();           
            SqlDataReader supervisorReader = supervisors_.ExecuteReader();    
                      
            supervisorReader.Close();
            mConnection.Close();



           

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            


            
            SqlCommand insert = new SqlCommand();
            insert.CommandType = System.Data.CommandType.Text;
            insert.CommandText = $"INSERT into Users_( FirstName, LastName, email,[password],Supervisor,Classification) Values('{FirstName.Text}','{LastName.Text}','{emailInput_Copy.Text}','Team1','{Supervisor.Text}','Student')";
            insert.Connection = mConnection;
            mConnection.Open();
            try
            {
                insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            mConnection.Close();
            MessageBox.Show("User added"); // + user id number


        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
           

            mConnection.Open();
            SqlCommand delete = new SqlCommand("DELETE From Users_(User_Id, FirstName, LastName, email) Values('" + mId + "', '" + mName + "', '" + mEmail + "')", mConnection);
            delete.ExecuteNonQuery();

            MessageBox.Show("User deleted");

            mConnection.Close();
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
            reader.Close();
            
            mConnection.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            MySupervisn_Team1._Users_2_0DataSet _Users_2_0DataSet = ((MySupervisn_Team1._Users_2_0DataSet)(this.FindResource("_Users_2_0DataSet")));
            // Load data into the table Users_. You can modify this code as needed.
            MySupervisn_Team1._Users_2_0DataSetTableAdapters.Users_TableAdapter _Users_2_0DataSetUsers_TableAdapter = new MySupervisn_Team1._Users_2_0DataSetTableAdapters.Users_TableAdapter();
            _Users_2_0DataSetUsers_TableAdapter.Fill(_Users_2_0DataSet.Users_);
            System.Windows.Data.CollectionViewSource users_ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("users_ViewSource")));
            users_ViewSource.View.MoveCurrentToFirst();
        }

        private void Supervisors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            delete.IsEnabled = true;
        }
    }
}
/*  mConnection.Close();
            mConnection.Open();
            SqlCommand search = new SqlCommand();

            search.CommandText = "select User_Id, Classification, FirstName, LastName,email,Supervisor from [Users_] where Classification='Student'";
            search.Connection = mConnection;
            SqlDataReader reader = search.ExecuteReader();

            Students.ItemsSource = reader;*/
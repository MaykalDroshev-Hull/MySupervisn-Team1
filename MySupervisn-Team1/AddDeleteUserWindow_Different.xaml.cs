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

      

        private StaffDashboard mDashboard;

        public AddDeleteUserWindow(StaffDashboard dashboard)
        {
            InitializeComponent();

            mDashboard = dashboard;

            Supervisor.Text += "Write N/A if not applicable";

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
            mConnection = DatabaseManager.CreateConnectionToDatabase();

            if (FirstName.Text != string.Empty && LastName.Text != string.Empty && Email.Text != string.Empty && Supervisor.Text != string.Empty)
            {
                int newId = 0;
                mConnection.Open();
                using (mConnection)
                {//SELECT TOP 1 * FROM Table ORDER BY ID DESC
                    string queryMax = "SELECT TOP 1 User_Id FROM Users_ ORDER BY User_Id DESC";
                    using (SqlCommand command1 = new SqlCommand(queryMax, mConnection))
                    {
                        SqlDataReader reader = command1.ExecuteReader();
                        reader.Read();
                        newId = int.Parse(reader[0].ToString());
                        newId++;
                        mConnection.Close();
                    }
                }

                mConnection = DatabaseManager.CreateConnectionToDatabase();
                using (mConnection)
                {
                    string query = "INSERT INTO Users_ (User_Id, FirstName, LastName, email,password, Supervisor, Classification) VALUES (@User_Id, @FirstName, @LastName, @email, 'Team1',@Supervisor, @Classification)";
                    mConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, mConnection))
                    {
                        command.Parameters.AddWithValue("@User_Id", newId);
                        command.Parameters.AddWithValue("@FirstName", FirstName.Text);
                        command.Parameters.AddWithValue("@LastName", LastName.Text);
                        command.Parameters.AddWithValue("@email", Email.Text);
                        command.Parameters.AddWithValue("@Supervisor", Supervisor.Text);
                        command.Parameters.AddWithValue("@Classification", Classification.Text);

                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        else
                        {
                            MessageBox.Show("User successfully saved! Id number: " + newId);

                            FirstName.Clear();
                            LastName.Clear();
                            Email.Clear();
                            Supervisor.Clear();
                        }
                    }
                }
            }
            else { MessageBox.Show("Empty field detected, please fill in everything"); }

            mConnection.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
                mConnection = DatabaseManager.CreateConnectionToDatabase();

                using (mConnection)
                {
                    mConnection.Open();

                    string userId = DeleteInput.Text;

                    using (SqlCommand command = new SqlCommand("DELETE FROM  Users_ WHERE User_Id = " + userId + "", mConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("User successfully deleted!");

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

        private void DeleteInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DeleteInput.Text != string.Empty)
            {
                Delete.IsEnabled = true;
            }
            else
            {
                Delete.IsEnabled = false;
            }
        }

        private void Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Delete.IsEnabled = true;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            mDashboard.Show();
        }
        private void DataWindow_Closing(object sender, EventArgs e)
        {
            mConnection.Close();
            Environment.Exit(1);
        }

    }
}

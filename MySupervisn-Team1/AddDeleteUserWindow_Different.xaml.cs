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

            mConnection.Open();

            string personalSupervisor = MenuItem.HeaderProperty.Name; // Not sure, want assign name of PS selected from the scroll down menu

            SqlCommand search = new SqlCommand();
            search.CommandText = "select User_Id, FirstName, LastName, email from [Users_]";
            search.Connection = mConnection;
            SqlDataReader reader = search.ExecuteReader();

            while (reader.Read())
            {
                idRow.Text += reader[0].ToString() + "\n";
                nameRow.Text += reader[1].ToString() + " " + reader[2].ToString() + "\n";
                emailRow.Text += reader[3].ToString() + "\n";
            }

            mConnection.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            mId = int.Parse(idInput.Text);
            mName = nameInput.Text;
            mEmail = emailInput.Text;

            mConnection.Open();
            SqlCommand insert = new SqlCommand("INSERT into Users_(User_Id, FirstName, LastName, email ) Values('" + mId + "', '" + mName + "', '" + mEmail + "')", mConnection);
            insert.ExecuteNonQuery();

            MessageBox.Show("User added"); // + user id number

            mConnection.Close();
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            mId = int.Parse(idInput.Text);
            mName = nameInput.Text;
            mEmail = emailInput.Text;

            mConnection.Open();
            SqlCommand delete = new SqlCommand("DELETE From Users_(User_Id, FirstName, LastName, email) Values('" + mId + "', '" + mName + "', '" + mEmail + "')", mConnection);
            delete.ExecuteNonQuery();

            MessageBox.Show("User deleted");

            mConnection.Close();
        }
    }
}

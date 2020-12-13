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
        /*System.Data.SqlClient.SqlConnection sqlConnection1 = 
    new System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING");

System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = System.Data.CommandType.Text;
cmd.CommandText = "INSERT Region (RegionID, RegionDescription) VALUES (5, 'NorthWestern')";
cmd.Connection = sqlConnection1;

sqlConnection1.Open();
cmd.ExecuteNonQuery();
sqlConnection1.Close();
        INSERT into Users_(User_Id, FirstName, LastName, email,password,Supervisor,Classification) Values('" + mId + "', '" + NameSplit[0] + "','" + NameSplit[1] + "','" + emailInput.Text + "','Team1','John Grey','Student')"*/
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            mId = int.Parse(idInput.Text);
            mName = nameInput.Text;
            mEmail = emailInput.Text;

            
            string[] NameSplit = mName.Split(' ');
            SqlCommand insert = new SqlCommand();
            insert.CommandType = System.Data.CommandType.Text;
            insert.CommandText= "INSERT into Users_(User_Id, FirstName, LastName, email,[password],Supervisor,Classification) Values(5,'Maykal','Droshev','mdroshev@gmail.com','Team1','John Grey','Student')";
            insert.Connection = mConnection;
            mConnection.Open();
            try
            {
                insert.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            mConnection.Close();
            MessageBox.Show("User added"); // + user id number

            
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

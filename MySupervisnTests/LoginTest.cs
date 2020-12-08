using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Data.SqlClient;
using MessageBox = System.Windows;

namespace MySupervisnTests
{
    [TestClass]
    public class LoginTest
    {
        private bool username_match = false;
        private bool password_match = false;

        [TestMethod]
        public void LoginValidCredentials()
        {
            // Pass - Both Username and Password are valid
            string username = "";
            string password = "";
            string expected = "Valid";

            // Arrange

            // Act
            bool username_match = false;
            bool password_match = false;

            // Assert
            //double actual = account.Balance;
           //Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void LoginNotValidCredentials()
        {
            // Not Pass - Username valid but Password Not valid
            string username = "";
            string password = "";

            // Not Pass - Username Not valid but Password valid
            //username = "";
            //password = "";

            // Arrange

            // Act
        

            // Assert
            //double actual = account.Balance;
            //Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\micha\Documents\GitHub\MySupervisn-Team1\MySupervisn-Team1\Users.mdf;Integrated Security=true";
            conn.Open();
            SqlCommand search = new SqlCommand();
            search.CommandText = "select User_Id,password,Classification from [Table]";
            search.Connection = conn;
            SqlDataReader reader = search.ExecuteReader();
            string Classification = "";
            while (reader.Read())
            {
                if (reader[0].ToString() == username)
                {
                    username_match = true;
                    if (reader[1].ToString() == password)
                    {
                        Classification = reader[2].ToString();
                        password_match = true;
                        break;
                    }

                }
            }

            if (username_match && password_match)
            {
                switch (Classification)
                {
                    case "Student":
                        break;
                    case "Student Hub":

                        break;
                    case "Personal Supervisor":
                        break;
                    case "Director of Study":
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                InitializeComponent();
            }
        }

    }
}

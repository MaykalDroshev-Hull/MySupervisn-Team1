using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MessageBox = System.Windows.MessageBox;
using System.IO;

namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        bool username_match = false;
        bool password_match = false;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;

            SqlConnection connection = new SqlConnection();
            var path = Environment.CurrentDirectory + @"\DataBase\Users.mdf";
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            connection.Open();

            SqlCommand search = new SqlCommand();
            search.CommandText = "select User_Id, password, Classification, FirstName, LastName,email,password,Supervisor from [Users_]";
            search.Connection = connection; 
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
            
            if (username_match && password_match) {
                int userId = int.Parse(username);
                string userName = reader[3].ToString() + reader[4].ToString();
                switch (Classification)
                {
                    case "Student":

                        this.Hide();
                        Student student = new Student(int.Parse(reader[0].ToString()), reader[3].ToString(), null, null);
                        StudentDashboard dashboard = new StudentDashboard(student);                        
                        dashboard.Show();
                        break;
                    case "Student Hub":
                        this.Hide();
                        StudentHub studentHub = new StudentHub(userId, userName, Classification);
                        StaffDashboard staffDashboard = new StaffDashboard(studentHub);
                        staffDashboard.Show();
                        break;
                    case "Personal Supervisor":
                        this.Hide();
                        Supervisor supervisor = new Supervisor(userId, userName, Classification);
                        StaffDashboard staffDashboard_PS = new StaffDashboard(supervisor);
                        staffDashboard_PS.Show();                      
                        break;
                    case "Director of Study":
                        this.Hide();
                        DirectorOfStudy director = new DirectorOfStudy(userId, userName, Classification);
                        StaffDashboard staffDashboard_DoS = new StaffDashboard(director);
                        staffDashboard_DoS.Show();
                        break;
                }
            }
            else {
              
                   MessageBox.Show("Invalid credentials", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                InitializeComponent();
            
            }
        }
    }
}

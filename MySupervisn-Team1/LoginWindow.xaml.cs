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
        SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();

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

            //var path = Environment.CurrentDirectory + @"\DataBase\Users.mdf";
            //mConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

            mConnection.Open();
            SqlCommand search = new SqlCommand();
            search.CommandText = "select User_Id, password, Classification, FirstName, LastName,email,password,Supervisor from [Users_]";
            search.Connection = mConnection; 
            SqlDataReader reader = search.ExecuteReader();
            string classification = ""; 
            while (reader.Read())
            {
                if (reader[0].ToString() == username)
                {
                    username_match = true;
                    if (reader[1].ToString() == password)
                    {
                        classification = reader[2].ToString();
                        password_match = true;
                        break;
                    }
                    
                }
            }
            
            if (username_match && password_match) {

                int userId = int.Parse(reader[0].ToString());
                string firstName = reader[3].ToString();
                string lastName = reader[4].ToString();
                string userName = firstName + " " + lastName;

                switch (classification)
                {
                    case "Student":
                        this.Hide();
                        //
                        // select NAME, Modules.name, Module.Mark From student INNER JOIN Modules On id-Modules.Student_id
                        //search.CommandText = "select* from Modules";
                        // SELECT, UPDATE, DELETE
                        //SELECT FirstName,LastName,ModuleName,Mark FROM Users_ INNER JOIN Modules ON User_Id=Modules.StudentID
                        //
                        /*
                        List<(string, byte)> modulesAndMarks = new List<(string, byte)>();
                        connection.Close();
                        connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
                        connection.Open();
                        search.CommandText = "SELECT ModuleName, Mark FROM Modules";
                        search.Connection = connection;
                        reader = search.ExecuteReader();
                        
                        string moduleChoices = reader[0].ToString();
                        int moduleMarks = int.Parse(reader[1].ToString());
                        */
                        /*
                        foreach(string module in reader[0].ToString())
                        {

                        }
                        for (int i = 0; i < reader[0].ToString().Length; i++)
                        {
                            modulesAndMarks.Add(reader[0].ToString()[i]);
                        }
                        */
                        List<Message> messages = new List<Message>();
                        //search.CommandText = "SELECT ModuleName, Mark FROM Users_ INNER JOIN Modules ON User_Id = Modules.StudentID";

                        // TO TEST
                        string moduleChoices = "AI";
                        int moduleMarks = 70;
                        List<(string, byte)> modulesAndMarks = new List<(string, byte)>();
                        modulesAndMarks.Add((moduleChoices, (byte)moduleMarks));

                        Student student = new Student(userId, userName, modulesAndMarks, messages);

                        StudentDashboard dashboard = new StudentDashboard(student);                        
                        dashboard.Show();
                        break;
                    case "Student Hub":
                        this.Hide();
                        StudentHub studentHub = new StudentHub(userId, userName, classification);
                        StaffDashboard staffDashboard = new StaffDashboard(studentHub);
                        staffDashboard.Show();
                        break;
                    case "Personal Supervisor":
                        this.Hide();
                        PersonalSupervisor personalSupervisor = new PersonalSupervisor(userId, userName, classification);
                        StaffDashboard staffDashboard_PS = new StaffDashboard(personalSupervisor);
                        staffDashboard_PS.Show();                      
                        break;
                    case "Director of Study":
                        this.Hide();
                        DirectorOfStudy director = new DirectorOfStudy(userId, userName, classification);
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

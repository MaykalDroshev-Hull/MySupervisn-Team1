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
        private SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();

        public LoginWindow()
        {
            InitializeComponent();
        }
        bool username_match = false;
        bool password_match = false;
        public void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;
           
            mConnection.Open();
            SqlCommand search = new SqlCommand();
            //search.CommandText = "select User_Id, password, Classification, FirstName, LastName,email,password,Supervisor from [Users_]";
            search.CommandText = "select User_Id, password, Classification, FirstName, LastName,email,password,Supervisor,Message.Body,Message.Subject,Message.Sender from [Users_] full outer join Message on FirstName+' '+LastName=Message.Receiver ";
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

                string MessageSubject = reader[9].ToString();
                string messageBody = reader[8].ToString();
                string _sender = reader[10].ToString();
                Message message = new Message(0, DateTime.Now, MessageSubject, messageBody, _sender, null);
                List<Message> messages = new List<Message>();
                messages.Add(message);

                switch (classification)
                {
                    case "Student":

                        this.Hide();                          
                        Student student = new Student(userId, userName, messages);
                        StudentDashboard dashboard = new StudentDashboard(student);                        
                        dashboard.Show();

                        break;
                    case "Student Hub":

                        this.Hide();
                        StudentHub studentHub = new StudentHub(userId, userName, classification,messages);
                        StaffDashboard staffDashboard = new StaffDashboard(studentHub,messages);
                        staffDashboard.Show();

                        break;
                    case "Personal Supervisor":

                        this.Hide();
                        PersonalSupervisor personalSupervisor = new PersonalSupervisor(userId, userName, classification, messages);
                        StaffDashboard staffDashboard_PS = new StaffDashboard(personalSupervisor,messages);
                        staffDashboard_PS.Show();                      
                        break;

                    case "Director of Study":
                        this.Hide();
                        DirectorOfStudy director = new DirectorOfStudy(userId, userName, classification, messages);
                        StaffDashboard staffDashboard_DoS = new StaffDashboard(director,messages);
                        staffDashboard_DoS.Show();
                        break;
                }
            }
            else {
              
                   MessageBox.Show("Invalid credentials", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                   InitializeComponent();
            
            }
            mConnection.Close();
        }
        private void DataWindow_Closing(object sender, EventArgs e)
        {
            mConnection.Close();
            Environment.Exit(1);
        }

      
    }
}

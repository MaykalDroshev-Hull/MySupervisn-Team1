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

namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool username_match = false;
        bool password_match = false;
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
            SqlDataReader rd = search.ExecuteReader();
            string Classification = "";
            while (rd.Read())
            {
                if (rd[0].ToString() == username)
                {
                    username_match = true;
                    if (rd[1].ToString() == password)
                    {
                        Classification = rd[2].ToString();
                        password_match = true;
                        break;
                    }
                    
                }
            }
            
            if (username_match && password_match) {
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
            else {
              
                   MessageBox.Show("Invalid credentials", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                InitializeComponent();
            
            }


        }
    }
}

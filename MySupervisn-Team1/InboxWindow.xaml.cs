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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class InboxWindow : Window
    {
        private User mUser;
        private Student mStudent;
        SqlConnection mConnection = new SqlConnection();

        public InboxWindow(Student pStudent)
        {
            InitializeComponent();
         
            mStudent = pStudent;

            CreateConnectionToDatabase();
        }
        public InboxWindow(User pUser)
        {
            InitializeComponent();
       
            mUser = pUser;

            CreateConnectionToDatabase();
        }

        private void CreateConnectionToDatabase()
        {
            var path = Environment.CurrentDirectory + @"\DataBase\Users.mdf";
            mConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (MainBody.Text != null)
            {
                SqlCommand insert = new SqlCommand("Insert into Messages(body, Subject) Values('" + MainBody.Text + "', '" + Subject.Text + "')", mConnection);
                mConnection.Open();
                insert.ExecuteNonQuery();

                MessageBox.Show("Message saved and sent");

                mConnection.Close();
            }

            //insert.Connection = connection;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            StudentDashboard studentDashboardWindow = new StudentDashboard(mStudent);
            studentDashboardWindow.Show();
        }
    }
}

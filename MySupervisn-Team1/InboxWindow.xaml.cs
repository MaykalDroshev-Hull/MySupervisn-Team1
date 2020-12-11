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
        private Staff mStaff;
        private Student mStudent;
        SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();

        public InboxWindow(Student pStudent)
        {
            InitializeComponent();
         
            mStudent = pStudent;
        }
        public InboxWindow(Staff pStaff)
        {
            InitializeComponent();
       
            mStaff = pStaff;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (MainBody.Text != null)
            {
                mConnection.Open();
                SqlCommand insert = new SqlCommand("Insert into Messages(body, Subject) Values('" + MainBody.Text + "', '" + Subject.Text + "')", mConnection);
                insert.ExecuteNonQuery();

                MessageBox.Show("Message saved and sent");

                mConnection.Close();
            }

            //insert.Connection = connection;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();

            if (mStudent != null)
            {
                StudentDashboard studentDashboardWindow = new StudentDashboard(mStudent);
                studentDashboardWindow.Show();

            }
            else
            {
                StaffDashboard staffDashboardWindow = new StaffDashboard(mStaff);
                staffDashboardWindow.Show();
            }
        }
    }
}

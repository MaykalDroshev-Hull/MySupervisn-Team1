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
    public partial class Inbox
    {
        private SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();

        private Staff mStaff;
        private Student mStudent;

        private int mId;
        private string mSender;

        public Inbox(Student pStudent)
        {
            InitializeComponent();

            mStudent = pStudent;
            mId = pStudent.IdNumber;
            mSender = pStudent.Name;
        }
        public Inbox(Staff pStaff)
        {
            InitializeComponent();
       
            mStaff = pStaff;
            mId = pStaff.IdNumber;
            mSender = pStaff.Name;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (MainBody.Text != null)
            {
                DateTime nowTime = new DateTime();

                mConnection.Open();
                SqlCommand insert = new SqlCommand("Insert into Message(Id, Sender, Receiver, Subject, Date, Body) Values('" + mId + "', '" + mSender + "', '"+ Receiver.Text + "', '" + Subject.Text + "', '"+ nowTime +"', '" + MainBody.Text + "')", mConnection);
                insert.ExecuteNonQuery();

                MessageBox.Show("Message saved and sent");
                Receiver.Clear();
                Subject.Clear();
                MainBody.Clear();

                mConnection.Close();
            }
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

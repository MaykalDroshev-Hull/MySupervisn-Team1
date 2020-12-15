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


        public List<Message> Messages1
        {
            get;
            set;
        }

        private int mId;
        private string mSender;

        public Inbox(Student pStudent, List<Message> messages)
        {
            InitializeComponent();
            Messages1 = messages;
            mStudent = pStudent;
            mId = pStudent.IdNumber;
            mSender = pStudent.Name;
            Messages.Items.Add($"Subject: {messages[0].Subject} \n Body:{messages[0].Body}");
        }
        public Inbox(Staff pStaff, List<Message> messages)
        {
            InitializeComponent();
            Messages1 = messages;
            mStaff = pStaff;
            mId = pStaff.IdNumber;
            mSender = pStaff.Name;
            Messages.Items.Add($"Subject: {messages[0].Subject} \n Body:{messages[0].Body}");
        }
        public Inbox(Staff staff, string receiver)
        {
            mStaff = staff;
            InitializeComponent();
            try
            {
                Messages.Items.Add($"Subject: {staff.messages1[0].Subject} \n Body:{staff.messages1[0].Body}");
            }
            catch (System.NullReferenceException)
            {
                Messages.Items.Add("No messages to show");
            }

            Receiver.Text = receiver;
            Subject.Focus();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (MainBody.Text != string.Empty || Subject.Text != string.Empty || Receiver.Text != string.Empty)
            {
                int maxid = 0;
                mConnection.Open();
                using (mConnection)
                {//SELECT TOP 1 * FROM Table ORDER BY ID DESC
                    string queryMax = "SELECT TOP 1 id FROM Message ORDER BY id DESC";
                    using (SqlCommand command1 = new SqlCommand(queryMax, mConnection))
                    {
                        SqlDataReader reader = command1.ExecuteReader();
                        reader.Read();
                        maxid = int.Parse(reader[0].ToString());
                        maxid++;
                        mConnection.Close();
                    }
                }

                mConnection = DatabaseManager.CreateConnectionToDatabase();
                using (mConnection)
                {
                    string query = "INSERT INTO Message (id, Sender, Receiver, Subject, Date, Body) VALUES (@id,@sender,@receiver,@subject,GETDATE(),@body)";
                    mConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, mConnection))
                    {
                        command.Parameters.AddWithValue("@id", maxid);
                        command.Parameters.AddWithValue("@sender", mSender.ToString());
                        command.Parameters.AddWithValue("@receiver", Receiver.Text);
                        command.Parameters.AddWithValue("@subject", Subject.Text);
                        command.Parameters.AddWithValue("@body", MainBody.Text);
                      
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        else
                        {
                            MessageBox.Show("Message saved and sent");
                        }
                    }
                }
            }
            else { MessageBox.Show("Empty field detected, please fill in everything"); }
            Receiver.Clear();
            Subject.Clear();
            MainBody.Clear();

            mConnection.Close();
        }
        private void DataWindow_Closing(object sender, EventArgs e)
        {
            mConnection.Close();
            Environment.Exit(1);
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            if (mStudent != null)
            {
                StudentDashboard studentDashboardWindow = new StudentDashboard(mStudent);
                studentDashboardWindow.Show();
            }
            else
            {
                StaffDashboard staffDashboardWindow = new StaffDashboard(mStaff, mStaff.messages1);
                staffDashboardWindow.Show();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Subject.Text = "";
            Receiver.Text = "";
            MainBody.Text = "";
        }
    }
}

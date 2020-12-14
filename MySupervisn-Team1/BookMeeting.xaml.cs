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
    /// Interaction logic for BookMeeting.xaml
    /// </summary>
    public partial class BookMeeting : Window

    {
        private SqlConnection mConnection = DatabaseManager.CreateConnectionToDatabase();
        private User mUser;
        

        public BookMeeting(Student pStudent)
        {
            InitializeComponent();

            mUser = pStudent;
        }
        public BookMeeting(Staff pStaff)
        {
            InitializeComponent();

            mUser = pStaff;
        }
        public BookMeeting(Staff pStaff, string name) : this(pStaff)
        {
            InitializeComponent();
            people.Text = ($"{pStaff.Name};{name}");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
           if(mUser is Student)
            {
                StudentDashboard studentDashboardWindow = new StudentDashboard((Student)mUser);
                studentDashboardWindow.Show();
            }
            else
            {
                StaffDashboard staffDashboard=new StaffDashboard((PersonalSupervisor)mUser);
            }
               
           
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            if (Subject.Text != string.Empty || _Datetime.Text != string.Empty || Time.Text != string.Empty||people.Text!=string.Empty)
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
                        command.Parameters.AddWithValue("@sender", mUser.Name.ToString());
                        command.Parameters.AddWithValue("@receiver", people.Text);
                        command.Parameters.AddWithValue("@subject", Subject.Text);
                        command.Parameters.AddWithValue("@body", _Datetime.Text+" "+Time.Text);

                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                        else
                        {
                            MessageBox.Show("Meeting saved and sent");
                        }
                    }
                }
            }
            else { MessageBox.Show("Empty field detected, please fill in everything"); }
            Subject.Clear();
            _Datetime.Text = "";
            Time.Clear();
            people.Clear();

            mConnection.Close();
        }
    }
}

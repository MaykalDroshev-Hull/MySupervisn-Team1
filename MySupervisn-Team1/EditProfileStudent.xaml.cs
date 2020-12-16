using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace MySupervisn_Team1
{
    public partial class EditProfileStudent : Window
    {
        private User mUser;

        public EditProfileStudent(Student student)
        {
            InitializeComponent();

            mUser = student;

            LblStdName.Content = mUser.Name;
            LblStdID.Content = "ID: "+ mUser.IdNumber;
            LblStdName.Content = "Name: " + student.Name;
            string email = student.Name.ToLower();
            string[] namearr = email.Split(' ');
            email = "";
            email += namearr[0];
            email += namearr[1];
            email += "@hull.ac.uk";

        }
        public EditProfileStudent(Staff pStaff)
        {
            InitializeComponent();

            mUser = pStaff;

            LblStdName.Content = pStaff.Name;
            LblStdID.Content += "ID: " + pStaff.IdNumber;
            LblStdName.Content = "Name: " + pStaff.Name;
            string email = pStaff.Name.ToLower();
            string[] namearr = email.Split(' ');
            email = "";
            email += namearr[0];
            email += namearr[1];
            email += "@hull.ac.uk";
        }

        private void BtnChangeName_Click(object sender, RoutedEventArgs e)
        {


            SqlConnection connection = DatabaseManager.CreateConnectionToDatabase();            
            connection.Open();

            string tFirstName = TbFirstName.Text;
            string tLastName = TbUSurName.Text;
            string commandtext = "UPDATE Users_ SET FirstName = @FN, LastName = @LN " + "WHERE User_Id = @ID;";

            SqlCommand update = new SqlCommand(commandtext, connection);
            update.Parameters.Add("@FN", System.Data.SqlDbType.VarChar);
            update.Parameters["@FN"].Value = tFirstName;
            update.Parameters.Add("@LN", System.Data.SqlDbType.VarChar);
            update.Parameters["@LN"].Value = tLastName;
            update.Parameters.Add("@ID", System.Data.SqlDbType.Int);
            update.Parameters["@ID"].Value = mUser.IdNumber;
                
            try
            {
                int rowsAffected = update.ExecuteNonQuery();
                MessageBox.Show("Changes made. Restart system to update.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (mUser is Staff)
            {
                Staff staff = mUser as Staff;
               StaffDashboard staffDashboard = new StaffDashboard((Staff)mUser,staff.messages1);
               staffDashboard.Show();
            }
            //if it is staff this should be null and goto catch block
            StudentDashboard studentDashboardWindow = new StudentDashboard((Student)mUser);
            studentDashboardWindow.Show();
            
            
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            if(TbOldPass.Text != TbNewPass.Text)
            {
                SqlConnection connection = DatabaseManager.CreateConnectionToDatabase();

               
                connection.Open();

                string commandtext = "UPDATE Users_ SET password = @PW " + "WHERE User_Id = @ID;";

                SqlCommand update = new SqlCommand(commandtext, connection);
                update.Parameters.Add("@PW", System.Data.SqlDbType.VarChar);
                update.Parameters["@PW"].Value = TbNewPass.Text;
                update.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                update.Parameters["@ID"].Value = mUser.IdNumber;
                try
                {
                    update.ExecuteNonQuery();
                    MessageBox.Show("Changes successful.");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString()) ;
                }
            }
            else
            {
                MessageBox.Show("Passwords match, please try again.");
            }
            
        }
        private void DataWindow_Closing(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}

﻿using System;
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
        private Student mStudent;
        private Staff staff;

        public EditProfileStudent(Student student)
        {
            InitializeComponent();

            mStudent = student;

            LblStdName.Content = mStudent.Name;
            LblStdID.Content = "ID: "+ mStudent.IdNumber;
            LblStdName.Content = "Name: " + student.Name;
            string email = student.Name.ToLower();
            string[] namearr = email.Split(' ');
            email = "";
            email += namearr[0];
            email += namearr[1];
            email += "@hull.ac.uk";

            Email.Content = "email: " + email;
        }
        public EditProfileStudent(Staff pStaff)
        {
            InitializeComponent();

            this.staff = pStaff;

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
            var path = Environment.CurrentDirectory + @"\DataBase\Users-2.0.mdf";
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            connection.Open();

            string tFirstName = TbFirstName.Text;
            string tLastName = TbUSurName.Text;
            string commandtext = "UPDATE Users SET FirstName = @FN, LastName = @LN " + "WHERE User_Id = @ID;";

            SqlCommand update = new SqlCommand(commandtext, connection);
            update.Parameters.Add("@FN", System.Data.SqlDbType.VarChar);
            update.Parameters["@FN"].Value = tFirstName;
            update.Parameters.Add("@LN", System.Data.SqlDbType.VarChar);
            update.Parameters["@LN"].Value = tLastName;
            update.Parameters.Add("@ID", System.Data.SqlDbType.Int);
            update.Parameters["@ID"].Value = mStudent.IdNumber;
                
            try
            {
                int rowsAffected = update.ExecuteNonQuery();
                MessageBox.Show("Changes made.)");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();

            if (mStudent.Equals(null))
            {
                StaffDashboard staffDashboard = new StaffDashboard(staff, staff.messages1);
                staffDashboard.Show();
            }
            //if it is staff this should be null and goto catch block
            StudentDashboard studentDashboardWindow = new StudentDashboard(mStudent);
            studentDashboardWindow.Show();
            
            
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            if(TbOldPass.Text != TbNewPass.Text)
            {
                SqlConnection connection = new SqlConnection();

                var path = Environment.CurrentDirectory + @"\DataBase\Users-2.0.mdf";
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
                connection.Open();

                string commandtext = "UPDATE Users SET PassWord = @PW " + "WHERE User_Id = @ID;";

                SqlCommand update = new SqlCommand(commandtext, connection);
                update.Parameters.Add("@PW", System.Data.SqlDbType.VarChar);
                update.Parameters["@PW"].Value = TbNewPass;
                update.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                update.Parameters["@ID"].Value = mStudent.IdNumber;
                try
                {
                    update.ExecuteNonQuery();
                    MessageBox.Show("Changes successful.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Changes failed.");
                }
            }
            else
            {
                MessageBox.Show("Passwords match, please try again.");
            }
        }
    }
}

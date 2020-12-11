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

        public EditProfileStudent(Student student)
        {
            InitializeComponent();

            mStudent = student;

            LblStdName.Content = mStudent.Name;
            LblStdID.Content += " "+ mStudent.IdNumber;
        }
            
        private void BtnChangeName_Click(object sender, RoutedEventArgs e)
        {
            //"I'll work on the staff dashboard"
            //"Kunle, edit the database"
            //"???"

            //TO DO (If we have time): Refactor so all of this in the DatabaseManager class;

            SqlConnection connection = new SqlConnection();
            var path = Environment.CurrentDirectory + @"\DataBase\Users.mdf";
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
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
            update.Parameters["@ID"].Value = mStudent.IdNumber;
                
            try
            {
                int rowsAffected = update.ExecuteNonQuery();
                MessageBox.Show("Changes made. Rows affected:" + rowsAffected.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();

            StudentDashboard studentDashboardWindow = new StudentDashboard(mStudent);
            studentDashboardWindow.Show();
        }

    }
}

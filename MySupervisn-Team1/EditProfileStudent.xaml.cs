using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace MySupervisn_Team1
{
    public partial class EditProfileStudent : Window
    {
        private Student mStudent;
        private Staff mStaff;

        public EditProfileStudent(Student pStudent)
        {
            InitializeComponent();

            mStudent = pStudent;
        }
        public EditProfileStudent(Staff pStaff)
        {
            InitializeComponent();

            mStaff = pStaff;
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

        private void btnChangeName_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

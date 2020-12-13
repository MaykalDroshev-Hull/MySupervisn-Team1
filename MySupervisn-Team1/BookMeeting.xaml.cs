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


namespace MySupervisn_Team1
{
    /// <summary>
    /// Interaction logic for BookMeeting.xaml
    /// </summary>
    public partial class BookMeeting : Window
    {
        private Student mStudent;
        private Staff mStaff;

        public BookMeeting(Student pStudent)
        {
            InitializeComponent();

            mStudent = pStudent;
        }
        public BookMeeting(Staff pStaff)
        {
            InitializeComponent();

            mStaff = pStaff;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            if(mStudent != null)
            {
                StudentDashboard studentDashboardWindow = new StudentDashboard(mStudent);
                studentDashboardWindow.Show();
            }
            else
            {
                StaffDashboard staffDashboardWindow = new StaffDashboard(mStaff,null);
                staffDashboardWindow.Show();
            }
        }
    }
}

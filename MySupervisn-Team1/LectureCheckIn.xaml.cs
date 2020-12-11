﻿using System;
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
    /// Interaction logic for Lectire_checkin.xaml
    /// </summary>
    public partial class LectureCheckIn : Window
    {
        private Student mStudent;
        private Staff mStaff;

        public LectureCheckIn(Student pStudent)
        {
            InitializeComponent();

            mStudent = pStudent;
        }
        public LectureCheckIn(Staff pStaff)
        {
            InitializeComponent();

            mStaff = pStaff;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Student:User
    {
        private string mStudentNumber;
        private List<(string, byte)> mModuleMarks;//Module,Mark
        private Dictionary<string, (byte, bool)> mModuleAttendance;//<Module code,(lecture number,IsAttended)>


        public void LectureCheck_in( string pModuleCode,byte pLectureNum)
        {
            throw new NotImplementedException();
        }
        public void ObserveActivity() {
            throw new NotImplementedException();
        }
    }
}

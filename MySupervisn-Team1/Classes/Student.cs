using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Student:User
    {
        //private string mStudentNumber; // If same as userID we already have in User an int mIdNumber
        private List<(string, byte)> mModulesAndMarks;//Module,Mark
        private Dictionary<string, (byte, bool)> mModuleAttendance;//<Module code,(lecture number,IsAttended)>
        private List<Message> mMessages;

        public List<(string, byte)> ModulesAndMarks { set { mModulesAndMarks = value; } get { return mModulesAndMarks;  } }//Module,Mark
        public Dictionary<string, (byte, bool)> ModuleAttendance { set { mModuleAttendance = value; } get { return mModuleAttendance; } }//<Module code,(lecture number,IsAttended)>
        public List<Message> Messages { set { mMessages = value; } get { return mMessages; } }

        public Student(int pIdNumber, string pName, List<(string, byte)> pModulesAndMarks, List<Message> pMessages) : base(pIdNumber, pName)
        {
            Role = "Student";
            IdNumber = pIdNumber;
            Name = pName;
            mModulesAndMarks = pModulesAndMarks;
            mMessages = pMessages;
        }
        public void LectureCheck_in( string pModuleCode,byte pLectureNum)
        {
            throw new NotImplementedException();
        }
        public void ObserveActivity() {
            throw new NotImplementedException();
        }
    }
}

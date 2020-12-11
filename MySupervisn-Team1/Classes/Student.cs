using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Student:User
    {
        
      
        private Dictionary<string, (byte, bool)> mModuleAttendance;//<Module code,(lecture number,IsAttended)>,Just concept,don't put into program
        public List<Message> mMessages;

        public Student(int pIdNumber, string pName,  List<Message> pMessages) : base(pIdNumber, pName)
        {
            Role = "Student";
            IdNumber = pIdNumber;
            Name = pName;
           
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

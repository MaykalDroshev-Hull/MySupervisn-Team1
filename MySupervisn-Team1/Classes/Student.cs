using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Student : User
    {


        public List<Message> mMessages;

        public Student(int pIdNumber, string pName, List<Message> pMessages) : base(pIdNumber, pName)
        {
            Role = "Student";
            IdNumber = pIdNumber;
            Name = pName;

            mMessages = pMessages;
        }
    }
}

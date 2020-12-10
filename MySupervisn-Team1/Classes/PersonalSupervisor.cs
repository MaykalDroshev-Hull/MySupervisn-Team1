using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class PersonalSupervisor:Staff
    {
        private List<Student> mStudents;

        public PersonalSupervisor(int pIdNumber, string pName) : base(pIdNumber, pName)
        {
            Role = "Personal Supervisor";
            IdNumber = pIdNumber;
            Name = pName;
        }
    }
}

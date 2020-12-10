using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Supervisor:Staff
    {
        private List<Student> mStudents;

        public Supervisor(int pIdNumber, string pName, string pRole) : base(pIdNumber, pName, pRole)
        {
            Role = pRole;
            IdNumber = pIdNumber;
            Name = pName;
        }
    }
}

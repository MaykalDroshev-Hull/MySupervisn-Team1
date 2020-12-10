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

        public Supervisor(int pIdNumber, string pName) : base(pIdNumber, pName)
        {
            Role = "Supervisor";
            IdNumber = pIdNumber;
            Name = pName;
        }
    }
}

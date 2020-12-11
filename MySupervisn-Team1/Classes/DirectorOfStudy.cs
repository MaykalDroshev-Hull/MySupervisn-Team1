using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class DirectorOfStudy: Staff
    {
        public DirectorOfStudy(int pIdNumber, string pName, string pRole) : base(pIdNumber, pName, pRole)
        {
            Role = pRole;
            IdNumber = pIdNumber;
            Name = pName;
        }

        public dynamic GenerateOverview()
        {
            throw new NotImplementedException();
        }
    }
}

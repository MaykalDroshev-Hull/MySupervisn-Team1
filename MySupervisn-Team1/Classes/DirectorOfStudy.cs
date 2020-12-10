using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class DirectorOfStudy: Staff
    {
        public DirectorOfStudy(int pIdNumber, string pName) : base(pIdNumber, pName)
        {
            Role = "Director of Study";
            IdNumber = pIdNumber;
            Name = pName;
        }

        public dynamic GenerateOverview()//
        {
            throw new NotImplementedException();
        }
    }
}

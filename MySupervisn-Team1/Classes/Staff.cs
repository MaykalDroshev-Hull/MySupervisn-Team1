using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Staff:User
    {
        public Staff(int pIdNumber, string pName, string pRole) : base(pIdNumber, pName)
        {
            Role = pRole;
            IdNumber = pIdNumber;
            Name = pName;
            
        }

        public void DeleteMessage()
        {
            throw new NotImplementedException();
        }
        public User SearchForUser()
        {
            throw new NotImplementedException();
        }
    }
}

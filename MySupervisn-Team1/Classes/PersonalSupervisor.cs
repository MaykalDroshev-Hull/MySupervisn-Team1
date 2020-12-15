using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class PersonalSupervisor:Staff
    {
        

        public PersonalSupervisor(int pIdNumber, string pName, string pRole,List<Message> messages) : base(pIdNumber, pName, pRole,messages)
        {
            this.messages1 = messages;
            Role = pRole;
            IdNumber = pIdNumber;
            Name = pName;
        }
    }
}

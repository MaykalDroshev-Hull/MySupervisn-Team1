using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{

    public abstract class User
    {
        private string mRole;
        private int mIdNumber;
        private string mName;      
        public string Role { set { mRole = value; }get{return mRole; } }
        public int IdNumber { set { mIdNumber = value; } get { return mIdNumber; } }
        public string Name { set { mName = value; } get { return mName; } }

        public User(int pIdNumber, string pName)
        {
            //
            mIdNumber = pIdNumber;
            mName = pName;
        }

      
    }
}

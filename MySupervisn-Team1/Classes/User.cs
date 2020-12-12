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
        private List<Message> _Notifications;
        private string _Password;

        public string Role { set { mRole = value; }get{return mRole; } }
        public int IdNumber { set { mIdNumber = value; } get { return mIdNumber; } }
        public string Name { set { mName = value; } get { return mName; } }

        public User(int pIdNumber, string pName)
        {
            //
            mIdNumber = pIdNumber;
            mName = pName;
        }

        private void SendMessage(Message pMessage)
        {
            DatabaseManager saveData = new DatabaseManager(pMessage);

            throw new NotImplementedException();
        }
        private void CreateMeeting(User pRecepient,Message pMessage)
        {
            throw new NotImplementedException();
        }
        private void LogIn()
        {

            throw new NotImplementedException();
        }
        /// <summary>
        /// Change the desired credentials based on a code
        /// </summary>
        /// <param name="pCode">0-email,1-name,2-password</param>
        /// <param name="pChange"></param>
        private void ChangeCredentials(byte pCode,string pChange)
        {
            throw new NotImplementedException();
        }
    }
}

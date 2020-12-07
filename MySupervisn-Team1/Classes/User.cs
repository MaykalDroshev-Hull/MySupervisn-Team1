using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class User
    {
        private string idNumber;
        private string email;
        private string name;
        private List<string> notifications;
        private string password;

        private void SendMessage(Message pMessage)
        {
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

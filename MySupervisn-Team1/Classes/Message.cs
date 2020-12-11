using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    public class Message
    {
        private int mMessageID;
        private DateTime mDateTime;
        private string mSubject;
        private string mBody;
        private string mModuleCode; // Are we keeping it?
        private User mSender;
        private User mRecipient;
        private string mDescription; // Is It the same as Body?

        public int MessageID {set{ mMessageID = value; } get{ return mMessageID; } }
        public DateTime DateTime { set { mDateTime = value; } get { return mDateTime; } }
        public string Subject { set { mSubject = value; } get { return mSubject; } } //
        public string Body { set { mBody = value; } get { return mBody; } }
        public string ModuleCode { set { mModuleCode = value; } get { return mModuleCode; } } // Are we keeping it?
        public User Sender { set { mSender = value; } get { return mSender; } }
        public User Recipient { set { mRecipient = value; } get { return mRecipient; } }
        public string Description { set { mDescription = value; } get { return mDescription; } } // Is It the same as Body?

        public Message(int pMessageID, DateTime pDateTime, string pSubject, string pBody, User pSender, User pRecipient )
        {
            mMessageID = pMessageID;
            mDateTime = pDateTime;
            mSubject = pSubject;
            mBody = pBody;
            mSender = pSender;
            mRecipient = pRecipient;
        }
    }
}

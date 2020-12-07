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
        private string mCaption;
        private DateTime mDateTime;
        private string mModuleCode;
        private User mSender;
        private User mRecipient;
        private string mDescription;

        public int MessageID {set{ mMessageID = value; } get{ return mMessageID; } }
        public string Caption { set { mCaption = value; } get { return mCaption; } }
        public DateTime DateTime { set { mDateTime = value; } get { return mDateTime; } }
        public string ModuleCode { set { mModuleCode = value; } get { return mModuleCode; } }
        public User Sender { set { mSender = value; } get { return mSender; } }
        public User Recipient { set { mRecipient = value; } get { return mRecipient; } }
        public string Description { set { mDescription = value; } get { return mDescription; } }
    }
}

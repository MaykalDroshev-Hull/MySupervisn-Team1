﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySupervisn_Team1
{
    class Meeting
    {
        private DateTime mDateTime;
        private User mInitiator;
        private List<User> mParticipants;
        private string mMeetTopic;
        /// <summary>
        /// send Notification to the List of users with the dateTime of the meeting,the Topic and the initiator
        /// </summary>
        public void SendNotification()
        {
            throw new NotImplementedException();
        }

        // In progress!!
        // Perhaps better to have SaveMeetingDates for PS
        // Then BookMeeting
        // DeleteMeeting
        public void SaveMeeting(string pTableName, int pId, string pName, DateTime pDate, List<string> pMessage)
        {
           // DatabaseManager saveMeetingToDatabase = new DatabaseManager(pTableName, pId, pName, pDate, pMessage);
        }
      
    }
}

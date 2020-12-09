using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupervisn_Team1
{
    //class StudentHub : Staff
    partial class StudentHub
    {
        /*
        public StudentHub(int pIdNumber, string pName) : base(pIdNumber, pName)
        {
            Role = "Student Hub";
            IdNumber = pIdNumber;
            Name = pName;
        }
        */
        public void AssignStudentToPS(Student pStudent,Supervisor pPersonalSupervisor)
        {
            throw new NotImplementedException();
        }
        public User AddUser(string pID,string pEmail,string pName, string pPassword,List<string> pStudentDetails)//if pStudentDetials is null is not student
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(User pUser) 
        {
            throw new NotImplementedException(); 
        }
    }
}

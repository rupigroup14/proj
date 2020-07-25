using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class ManagerComplaint
    {
        int managerID;
        int compID;
        string sendType;

        public int ManagerID { get => managerID; set => managerID = value; }
        public int CompID { get => compID; set => compID = value; }
        public string SendType { get => sendType; set => sendType = value; }

        public List<ManagerComplaint> GetManComplaints()
        {
            DBservices dbs = new DBservices();
            return dbs.getManComplaintsList();
        }
        public int insert(ManagerComplaint[] arr)
        {
            DBservices dbs = new DBservices();
            int numAffected = 0;
            foreach (var item in arr)
            {
                numAffected = dbs.insert(item);
            }

            return numAffected;
        }

        public int deleteMC(int number)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.deleteMC(number);
            return numAffected;
        }
    }
}
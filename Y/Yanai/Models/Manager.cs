using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class Manager
    {
        int managerID;
        string managerName;
        string password;
        int managerPhone;
        string managerJob;
        string alert;
        string email;
        string photo;
        string permissionType;

        public int ManagerID { get => managerID; set => managerID = value; }
        public string ManagerName { get => managerName; set => managerName = value; }
        public string Password { get => password; set => password = value; }
        public int ManagerPhone { get => managerPhone; set => managerPhone = value; }
        public string ManagerJob { get => managerJob; set => managerJob = value; }
        public string Alert { get => alert; set => alert = value; }
        public string Email { get => email; set => email = value; }
        public string Photo { get => photo; set => photo = value; }
        public string PermissionType { get => permissionType; set => permissionType = value; }

        public List<Manager> GetManagers()
        {
            DBservices dbs = new DBservices();
            return dbs.getManagersList();
        }
        public bool getManager(string username, string password)
        {
            DBservices dbs = new DBservices();
            return dbs.checkmanagerList(username, password);
        }

        public string getManEmail(int managerId)
        {
            DBservices dbs = new DBservices();
            List<Manager> list = dbs.getManagersList();

            foreach (Manager m in list)
            {
                if (managerId == m.ManagerID)
                    return m.Email;
            }
            return "";
        }

        public int getManID(string managername)
        {
            DBservices dbs = new DBservices();
            List<Manager> list = dbs.getManagersList();

            foreach (Manager m in list)
            {
                if (managername == m.ManagerName)
                    return m.ManagerID;
            }
            return 0;
        }
    }
}
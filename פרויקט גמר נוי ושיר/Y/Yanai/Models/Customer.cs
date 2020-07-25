using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class Customer
    {
        int custID;
        int custLogin;
        string custName;
        int custPhone;
        string custAddress;
        int managerID;

        public int CustID { get => custID; set => custID = value; }
        public int CustLogin { get => custLogin; set => custLogin = value; }
        public string CustName { get => custName; set => custName = value; }
        public int CustPhone { get => custPhone; set => custPhone = value; }
        public string CustAddress { get => custAddress; set => custAddress = value; }
        public int ManagerID { get => managerID; set => managerID = value; }

        public List<Customer> GetCustomers()
        {
            DBservices dbs = new DBservices();
            return dbs.getCustomersList();
        }
        public bool getCustomer(int idbycus)
        {
            DBservices dbs = new DBservices();
            return dbs.checkcustomerexist(idbycus);
        }

        public int getMID(int cusId)
        {
            DBservices dbs = new DBservices();
            List<Customer> list = dbs.getCustomersList();

            foreach (Customer c in list)
            {
                if (cusId == c.CustLogin)
                    return c.ManagerID;
            }
            return 0;
        }
    }
}
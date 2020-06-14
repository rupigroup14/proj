using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Yanai.Models
{
    public class Complaint
    {
        int compID;
        string orderDate;
        string lastUpdate;
        string openDate;
        string onTreatDate;
        string openType;
        string orderReport;
        string StatName;
        int cusLogin;
        string ModeOfTreatment;
        string openBy;
        bool archived;

        public int CompID { get => compID; set => compID = value; }
        public string OrderDate { get => orderDate; set => orderDate = value; }
        public string LastUpdate { get => lastUpdate; set => lastUpdate = value; }
        public string OpenDate { get => openDate; set => openDate = value; }
        public string OnTreatDate { get => onTreatDate; set => onTreatDate = value; }
        public string OpenType { get => openType; set => openType = value; }
        public string OrderReport { get => orderReport; set => orderReport = value; }
        public string StatName1 { get => StatName; set => StatName = value; }
        public int CusLogin { get => cusLogin; set => cusLogin = value; }
        public string ModeOfTreatment1 { get => ModeOfTreatment; set => ModeOfTreatment = value; }
        public string OpenBy { get => openBy; set => openBy = value; }
        public bool Archived { get => archived; set => archived = value; }

        public List<Complaint> GetComplaints()
        {
            DBservices dbs = new DBservices();
            return dbs.getComplaintsList();
        }

        public int insert(Complaint complaint)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(complaint);
            return numAffected;
        }

        public int Getcust(int number)
        {
            DBservices dbs = new DBservices();
            List<Complaint> list = dbs.getComplaintsList();

            foreach (Complaint c in list)
            {
                if (number == c.CompID)
                    return c.CusLogin;
            }
            return 0;
        }

        public int Upcomplaint(Complaint complaint)
        {

            DBservices dbs = new DBservices();
            dbs = dbs.readComplaints();
            dbs.dt = EditComp(complaint, dbs.dt);
            dbs.update();
            return 0;
        }

        public int UpcomplaintA(Complaint complaint)
        {

            DBservices dbs = new DBservices();
            dbs = dbs.readComplaints();
            dbs.dt = EditCompA(complaint, dbs.dt);
            dbs.update();
            return 0;
        }

        public int UpdateStatus(Complaint complaint)
        {

            DBservices dbs = new DBservices();
            dbs = dbs.readComplaints();
            dbs.dt = EditCompStatus(complaint, dbs.dt);
            dbs.update();
            return 0;
        }

        public DataTable EditComp(Complaint complaint, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                CompID = Convert.ToInt32(dr["CompID"]);
                if (complaint.CompID == CompID)
                {
                    if (complaint.OrderReport != null)
                    {
                        dr["lastUpdate"] = complaint.LastUpdate;
                        dr["onTreatDate"] = complaint.OnTreatDate;
                        dr["orderReport"] = complaint.OrderReport;
                        dr["StatusName"] = complaint.StatName1;
                        dr["ModeOfTreatment"] = complaint.ModeOfTreatment1;
                    }
                    else
                    {
                        dr["lastUpdate"] = complaint.LastUpdate;
                        dr["onTreatDate"] = complaint.OnTreatDate;
                        dr["StatusName"] = complaint.StatName1;
                        dr["ModeOfTreatment"] = complaint.ModeOfTreatment1;
                    }

                }
            }

            return dt;
        }

        public DataTable EditCompA(Complaint complaint, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                CompID = Convert.ToInt32(dr["CompID"]);
                if (complaint.CompID == CompID)
                {
                    dr["archived"] = complaint.Archived;
                }
            }

            return dt;
        }
        public List<Complaint> getnotArchived()
        {
            List<Complaint> CompNotArchived = new List<Complaint>();
            DBservices dbs = new DBservices();
            List<Complaint> list = dbs.getComplaintsList();

            foreach (Complaint c in list)
            {
                if (c.Archived == false)
                    CompNotArchived.Add(c);
            }
            return CompNotArchived;
        }

        public List<Complaint> getArchived()
        {
            List<Complaint> CompArchived = new List<Complaint>();
            DBservices dbs = new DBservices();
            List<Complaint> list = dbs.getComplaintsList();

            foreach (Complaint c in list)
            {
                if (c.Archived == true)
                    CompArchived.Add(c);
            }
            return CompArchived;
        }

        public DataTable EditCompStatus(Complaint complaint, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                CompID = Convert.ToInt32(dr["CompID"]);
                if (complaint.CompID == CompID)
                {
                    dr["onTreatDate"] = complaint.OnTreatDate;
                    dr["StatusName"] = complaint.StatName1;
                }
            }

            return dt;
        }

        public List<Complaint> GetFilteredComplaints(int managerId, int archived)
        {
            DBservices dbs = new DBservices();
            return dbs.getFilteredComplList(managerId, archived);
        }

        public List<Complaint> GetByStatus(string status)
        {
            List<Complaint> CompByStatus = new List<Complaint>();
            DBservices dbs = new DBservices();
            List<Complaint> list = dbs.getComplaintsList();

            foreach (Complaint c in list)
            {
                if (status == c.StatName1)
                    CompByStatus.Add(c);
            }
            return CompByStatus;
        }

        public List<Complaint> GetByManager(int[] arr)
        {
            List<Complaint> CompByManager = new List<Complaint>();
            DBservices dbs = new DBservices();
            List<Complaint> list = dbs.getComplaintsList();

            for (var i = 0; i < arr.Length; i++)
            {
                foreach (Complaint c in list)
                {
                    if (arr[i] == c.CusLogin)
                        CompByManager.Add(c);
                }
                return CompByManager;
            }
            return CompByManager;
        }
    }
}
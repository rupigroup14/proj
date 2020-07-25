using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class Problem
    {
        int probID;
        string Description1;
        string probType;
        int compID;
        string productName;

        public int ProbID { get => probID; set => probID = value; }
        public string Description11 { get => Description1; set => Description1 = value; }
        public string ProbType { get => probType; set => probType = value; }
        public int CompID { get => compID; set => compID = value; }
        public string ProductName { get => productName; set => productName = value; }

        public int insert(Problem[] arr)
        {
            DBservices dbs = new DBservices();
            int numAffected = 0;
            foreach (var item in arr)
            {
                numAffected = dbs.insert(item);
            }

            return numAffected;
        }

        public List<Problem> GetProblems()
        {
            DBservices dbs = new DBservices();
            return dbs.getProblemsList();
        }
    }
}
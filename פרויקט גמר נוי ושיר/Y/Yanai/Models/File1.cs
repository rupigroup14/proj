using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class File1
    {
        int fileID;
        int problemID;
        string description;
        string filepath;

        public int FileID { get => fileID; set => fileID = value; }
        public int ProblemID { get => problemID; set => problemID = value; }
        public string Description { get => description; set => description = value; }
        public string Filepath { get => filepath; set => filepath = value; }

        public int insert(File1[] arr)
        {
            DBservices dbs = new DBservices();
            int numAffected = 0;
            foreach (var item in arr)
            {
                numAffected = dbs.insert(item);
            }

            return numAffected;
        }

        public List<File1> GetFiles()
        {
            DBservices dbs = new DBservices();
            return dbs.getFilesList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class CommentFile
    {
        string FilePath;
        int commentID;

        public string FilePath1 { get => FilePath; set => FilePath = value; }
        public int CommentID { get => commentID; set => commentID = value; }

        public List<CommentFile> GetCommentsFiles()
        {
            DBservices dbs = new DBservices();
            return dbs.getCFilesList();
        }
        public int insert(CommentFile[] arr)
        {
            DBservices dbs = new DBservices();
            int numAffected = 0;
            foreach (var item in arr)
            {
                numAffected = dbs.insert(item);
            }

            return numAffected;
        }
    }
}
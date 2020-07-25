using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class Comment
    {
        int commentID;
        string commentTime;
        string commentDes;
        int managerID;
        int compID;

        public int CommentID { get => commentID; set => commentID = value; }
        public string CommentTime { get => commentTime; set => commentTime = value; }
        public string CommentDes { get => commentDes; set => commentDes = value; }
        public int ManagerID { get => managerID; set => managerID = value; }
        public int CompID { get => compID; set => compID = value; }

        public List<Comment> GetAllCommentsList()
        {
            DBservices dbs = new DBservices();
            return dbs.getCommentsList1();
        }

        public List<Comment> GetComments(int compnum)
        {
            DBservices dbs = new DBservices();
            return dbs.getCommentsList(compnum);
        }

        public int insert(Comment comment)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(comment);
            return numAffected;
        }
    }
}
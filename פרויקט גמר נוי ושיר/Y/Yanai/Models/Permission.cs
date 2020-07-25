using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yanai.Models
{
    public class Permission
    {
        string permissiontype;

        public string Permissiontype { get => permissiontype; set => permissiontype = value; }

        public List<Permission> GetPermissions()
        {
            DBservices dbs = new DBservices();
            return dbs.getPermissionsList();
        }
    }
}
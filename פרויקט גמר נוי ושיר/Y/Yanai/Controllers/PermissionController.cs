using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class PermissionController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Permission> Get()
        {
            return new Permission().GetPermissions();
        }
    }
}
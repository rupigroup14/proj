using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class ManagerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Manager> Get()
        {
            return new Manager().GetManagers();
        }

        [HttpGet]
        [Route("api/Manager/{username}/{password}")]
        public bool GetManagers(string username, string password)
        {
            Manager manager = new Manager();
            return manager.getManager(username, password);
        }

        [HttpGet]
        [Route("api/Manager/{managerId}")]
        public string GetManagerMail(int managerId)
        {
            Manager manager = new Manager();
            return manager.getManEmail(managerId);
        }

        [HttpGet]
        [Route("api/Manager/Name/{managername}")]
        public int GetManagerID(string managername)
        {
            Manager manager = new Manager();
            return manager.getManID(managername);
        }

    }
}
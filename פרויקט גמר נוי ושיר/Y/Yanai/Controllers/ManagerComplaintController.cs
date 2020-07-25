using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class ManagerComplaintController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ManagerComplaint> Get()
        {
            return new ManagerComplaint().GetManComplaints();
        }
        // POST api/<controller>
        public void Post([FromBody]ManagerComplaint[] arr)
        {
            ManagerComplaint mc = new ManagerComplaint();
            mc.insert(arr);
        }

        [HttpDelete]
        [Route("api/ManagerComplaint/{number}")]
        // DELETE api/<controller>/5
        public void Delete(int number)
        {
            ManagerComplaint mc = new ManagerComplaint();
            mc.deleteMC(number);
        }
    }
}
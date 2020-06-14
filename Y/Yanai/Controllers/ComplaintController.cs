using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class ComplaintController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Complaint> Get()
        {
            return new Complaint().GetComplaints();
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Complaint/insert")]
        public void Post([FromBody]Complaint complaint)
        {
            Complaint c = new Complaint();
            c.insert(complaint);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Complaint/update")]
        public int UpdateComplaint(Complaint complaint)
        {
            Complaint complaint1 = new Complaint();
            return complaint1.Upcomplaint(complaint);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Complaint/updateArchive")]
        public int UpdatetoArchive(Complaint complaint)
        {
            Complaint complaint1 = new Complaint();
            return complaint1.UpcomplaintA(complaint);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Complaint/updateStatus")]
        public int UpdateCompStatus(Complaint complaint)
        {
            Complaint complaint1 = new Complaint();
            return complaint1.UpdateStatus(complaint);
        }

        [HttpGet]
        [Route("api/Complaint/getCustID/{number}")]
        public int GetCustID(int number)
        {
            return new Complaint().Getcust(number);
        }

        [HttpGet]
        [Route("api/Complaint/getfiltered/{managerId}/{archived}")]
        public IEnumerable<Complaint> GetFiltered(int managerId, int archived)
        {
            return new Complaint().GetFilteredComplaints(managerId, archived);
        }

        [HttpGet]
        [Route("api/Complaint/getComByStatus/{status}")]
        public List<Complaint> GetComByStat(string status)
        {
            return new Complaint().GetByStatus(status);
        }

        [HttpGet]
        [Route("api/Complaint/CompByManager")]
        public List<Complaint> GetCompByMan([FromBody]int [] arr)
        {
            return new Complaint().GetByManager(arr);
        }

        [HttpGet]
        [Route("api/Complaint/getnotArchived")]
        public List<Complaint> GetnotArchived()
        {
            return new Complaint().getnotArchived();
        }

        [HttpGet]
        [Route("api/Complaint/getArchived")]
        public List<Complaint> GetArchived()
        {
            return new Complaint().getArchived();
        }
    }
}
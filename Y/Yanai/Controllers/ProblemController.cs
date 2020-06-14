using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class ProblemController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Problem[] arr)
        {
            Problem p = new Problem();
            p.insert(arr);
        }

        // GET api/<controller>
        public IEnumerable<Problem> Get()
        {
            return new Problem().GetProblems();
        }
    }
}
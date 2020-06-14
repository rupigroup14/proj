using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            return new Customer().GetCustomers();
        }

        [HttpGet]
        [Route("api/Customer/{idbycus}")]
        public bool GetCus(int idbycus)
        {
            Customer customer = new Customer();
            return customer.getCustomer(idbycus);
        }

        [HttpGet]
        [Route("api/Customer/getMID/{cusId}")]
        public int GetManagerID(int cusId)
        {
            Customer customer = new Customer();
            return customer.getMID(cusId);
        }
    }
}
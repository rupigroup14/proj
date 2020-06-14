using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            return new Product().GetProducts();
        }
    }
}
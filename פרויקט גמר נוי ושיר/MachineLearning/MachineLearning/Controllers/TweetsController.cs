using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TweetsController : ApiController
    {
        [HttpGet]
        [Route("api/Tweets/{text}")]
        public int Get(string text)
        {
            return new Tweet().Start(text);
        }
    }
}
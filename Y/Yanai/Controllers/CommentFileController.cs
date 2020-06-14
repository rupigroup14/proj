using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class CommentFileController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CommentFile> Get()
        {
            return new CommentFile().GetCommentsFiles();
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/CommentFile/insert")]
        public void Post([FromBody]CommentFile[] arr)
        {
            CommentFile cf = new CommentFile();
            cf.insert(arr);
        }
    }
}
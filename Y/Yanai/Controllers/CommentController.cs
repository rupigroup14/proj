using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

namespace Yanai.Controllers
{
    public class CommentController : ApiController
    {
        [HttpGet]
        [Route("api/Comment/read")]
        public IEnumerable<Comment> Get()
        {
            return new Comment().GetAllCommentsList();
        }

        [HttpGet]
        [Route("api/Comment/{compnum}")]
        public IEnumerable<Comment> Get(int compnum)
        {
            Comment comment = new Comment();
            return comment.GetComments(compnum);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Comment/insert")]
        public void Post([FromBody]Comment comment)
        {
            Comment c = new Comment();
            c.insert(comment);
        }
    }
}
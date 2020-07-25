using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yanai.Models;

using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace Yanai.Controllers
{
    public class FileController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<File1> Get()
        {
            return new File1().GetFiles();
        }

        // POST api/<controller>
        public void Post([FromBody]File1[] arr)
        {
            File1 f = new File1();
            f.insert(arr);
        }

        [HttpPost]
        [Route("api/File/upload")]
        public HttpResponseMessage Post()
        {
            List<string> fileLinks = new List<string>();
            var httpContext = HttpContext.Current;

            // Check for any uploaded file  
            if (httpContext.Request.Files.Count > 0)
            {
                //Loop through uploaded files  
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];

                    // this is an example of how you can extract addional values from the Ajax call
                    string name = httpContext.Request.Form["name"];

                    if (httpPostedFile != null)
                    {
                        // Construct file save path  
                        //var fileSavePath = Path.Combine(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileUploadFolder"]), httpPostedFile.FileName);
                        string fname = httpPostedFile.FileName.Split('\\').Last();
                        var fileSavePath = Path.Combine(HostingEnvironment.MapPath("~/uploadedFiles"), fname);
                        // Save the uploaded file  
                        httpPostedFile.SaveAs(fileSavePath);
                        fileLinks.Add("uploadedFiles/" + fname);
                    }
                }
            }

            // Return status code  
            return Request.CreateResponse(HttpStatusCode.Created, fileLinks);
        }
    }
}
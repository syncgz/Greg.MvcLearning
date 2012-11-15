using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.MediaFormatter;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FeedController : ApiController
    {
        // GET api/feed/5
        public HttpResponseMessage Get()
        {
            int a = 100;

            var resultObj = new Feed()
                {
                    Address = "http://www.wp.pl",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "",
                    Description = "Description",
                    Title = "Title",
                    UrlId = 1
                };


            return new HttpResponseMessage(){Content = new ObjectContent<Feed>(resultObj,new BufferedFeedFormatter("application/xml"),"application/xml")};
        }


    }
}

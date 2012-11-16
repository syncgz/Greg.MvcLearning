using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SimpleController : ApiController
    {
        public Feed Get()
        {
            return new Feed(){Title = "Simple Title of Feed."};
        }

        [HttpPost]
        public void Post(Feed f)
        {
            int a = 100;
        }
    }
}

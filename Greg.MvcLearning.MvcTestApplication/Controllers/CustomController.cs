using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greg.MvcLearning.MvcTestApplication.Controllers
{
    public class CustomController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Index2")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index2()
        {
            return View();
        }

    }
}

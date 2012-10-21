using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Greg.MvcTest.Controllers
{
    public class MainMenuController : Controller
    {
        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}

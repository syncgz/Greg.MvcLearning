using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MvcJQuery.Models;

namespace MvcJQuery.Controllers
{
    public class SummitController : Controller
    {
        public ActionResult Index()
        {
            List<Summit> list = new List<Summit>()
                {
                    new Summit(){Height = 1000,Name = "A"},
                    new Summit(){Height = 2000,Name = "B"},
                    new Summit(){Height = 3000,Name = "C"},
                    new Summit(){Height = 4000,Name = "D"}

                };

            return View(list);
        }

        public ActionResult AddSummit()
        {
            return View();
        }

        public ActionResult DeleteSummit()
        {
            return View();
        }
    }
}

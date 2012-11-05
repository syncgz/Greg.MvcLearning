using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxMvc2.Models;

namespace AjaxMvc2.Controllers
{
    public class JsonController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JsonAuction(long id)
        {
            Person p = new Person(){Id = 1,Name = "Name"};

            return Json(p, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult JsonAuction(Person person)
        {
            var xxx = person;

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Greg.MvcLearning.MvcTestApplication.Models;

namespace Greg.MvcLearning.MvcTestApplication.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new FormContainer(){Field1 = "123"});
        }

        [HttpPost]
        public ActionResult Index(FormContainer container)
        {
            return View(new FormContainer() { Field1 = "123" });
        }


    }
}

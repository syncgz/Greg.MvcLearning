using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMvc2.Controllers
{
    public class CustomAjax2Controller : Controller
    {
        private static List<string> _comments = new List<string>();
        
        public ActionResult Index()
        {
            return View(_comments);
        }
        
        [HttpPost]
        public ActionResult AddComment(string comment)
        {
            _comments.Add(comment);
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("AddComment",comment);
            }
            
            return RedirectToAction("Index");
        }

    }
}

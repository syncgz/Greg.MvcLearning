using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greg.MvcLearning.MvcTestApplication.Controllers
{
    public class ErrorController : Controller
    {
        public string Create()
        {
            return "abc";
        }

        public ActionResult Index()
        {
            throw new Exception("Exception information!!!");
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if(filterContext == null)
            {
                base.OnException(filterContext);    
            }
            
            //
            // Logika logowania
            //

            if(filterContext.HttpContext.IsCustomErrorEnabled)
            {
                filterContext.ExceptionHandled = true;
                this.View("Error").ExecuteResult(this.ControllerContext);
            }
        }

    }
}

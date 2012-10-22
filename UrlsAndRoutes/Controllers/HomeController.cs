using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult File()
        {
            return File(@"c:\Users\gzarnowski\Dropbox\Knowladge Wiki\Mvc\Books\Programming ASP.NET MVC 4.pdf",
                        "text/plain","abc.pdf");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMvc2.Controllers
{

    // Kontroler obslugujacy czesciowe odswiezanie strony czyli akcja
    //
    //Browser request bez parametrow --> Controller --> Browser
    //
    public class CustomAjaxController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }

            return View();
        }

    }
}

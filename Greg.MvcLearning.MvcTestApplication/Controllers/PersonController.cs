using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Greg.MvcLearning.MvcTestApplication.Models;

namespace Greg.MvcLearning.MvcTestApplication.Controllers
{
    public class PersonController : Controller
    {
        [ActionName("Index")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult WhateverNameYouWant()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            return View();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greg.MvcLearning.MvcTestApplication.Controllers
{
    public class AuctionController : Controller
    {
        //
        // GET: /Auction/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            var auction = new Auction
            {
                Id = id,
                Title = "Brand new Widget 2.0",
                Description = "This is a brand new version 2.0 Widget!",
                StartPrice = 1.00m,
                CurrentPrice = 13.40m,
                StartTime = DateTime.Parse("6-15-2012 12:34 PM"),
                EndTime = DateTime.Parse("6-23-2012 12:34 PM"),
            };

            return View(auction);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Auction/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Auction/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Auction/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Auction/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

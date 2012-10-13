using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greg.MvcLearning.MvcTestApplication.Controllers
{
    public class AuctionController : Controller
    {
        private List<Auction> _list = new List<Auction>(); 

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
            Auction auction = new Auction();
            
            return View(auction);
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            try
            {
                if(String.IsNullOrEmpty(auction.Title))
                {
                    ModelState.AddModelError("Title","Title cannot be null.");
                }

                if(ModelState.IsValid)
                {
                    _list.Add(auction);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(auction);
            }
            
            return View(auction);
          
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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

        public ActionResult Auction(int id = 0)
        {
            var item = new Auction()
                {
                    AuctionType = AuctionType.Type1,
                    CurrentPrice = 100,
                    Description = "Description",
                    EndTime = DateTime.Now,
                    Id = 1,
                    StartPrice = 10,
                    StartTime = DateTime.Now,
                    Title = "Title"
                };

            return View("Auction", item);
        }

        public ActionResult PartialAuction(int id = 0)
        {
            var item = new Auction()
            {
                AuctionType = AuctionType.Type1,
                CurrentPrice = 100,
                Description = "Description",
                EndTime = DateTime.Now,
                Id = 1,
                StartPrice = 10,
                StartTime = DateTime.Now,
                Title = "Title"
            };

            return PartialView("Auction",item);
        }

        public ActionResult NotFound()
        {
            return this.HttpNotFound();
        }

        public ActionResult Redirect()
        {
            
            return this.Redirect("http://www.wp.pl");
        }
    }
}

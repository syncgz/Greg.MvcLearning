using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Greg.MvcLearning.MvcTestApplication.Rest
{
    public class RestController : ApiController
    {
        [HttpGet]
        public IQueryable<Auction> GetMethod()
        {
            var auctionList = new List<Auction>()
                {
                    new Auction() {Id = 1},
                    new Auction() {Id = 2},
                    new Auction() {Id = 3},
                    new Auction() {Id = 4},
                    new Auction() {Id = 5},
                };

            return auctionList.AsQueryable();
        }

        [HttpPut]
        public void PutMethod()
        {
            
        }

        [HttpPost]
        public void PostMethod()
        {
            
        }

        [HttpDelete]
        public void DeleteMethod()
        {
            
        }
    }
}

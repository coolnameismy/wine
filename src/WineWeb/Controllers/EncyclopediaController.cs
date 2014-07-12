using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineWeb.Models;
using WineWeb.BL;
using MongoDB.Bson;
using MongoDB.Driver;
 
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB;
namespace WineWeb.Controllers
{
    public class EncyclopediaController : Controller
    {
        //
        // GET: /Encyclopedia/

        public ActionResult Index()
        {
            MongoDatabase db = Common.GetDatabase();

            var collection = db.GetCollection<Encyclopedia>("Encyclopedia");

            var query = collection.AsQueryable<Encyclopedia>();

            var result = query.OrderByDescending(i => i.date).ToList();
            foreach (var item in result)
            {
                string str = item.title;
                // process employees named "John"
            }


            return View(result);
        }

    }
   
}

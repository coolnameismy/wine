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
            var result = query;
            

            int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            int pageSize = 6; //设置每页显示条数
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, result.Count());

            return View(result.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        public ActionResult Details(string id)
        {
            MongoDatabase db = Common.GetDatabase();
            var encyclopedia = db.GetCollection<Encyclopedia>("Encyclopedia").AsQueryable<Encyclopedia>().Where(i => i.Id == id).FirstOrDefault();
            return View(encyclopedia);
        }

    }
   
}

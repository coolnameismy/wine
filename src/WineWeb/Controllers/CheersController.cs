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
    public class CheersController : Controller
    {
        //
        // GET: /Encyclopedia/

        public ActionResult Index()
        {

            MongoDatabase db = Common.GetDatabase();
            var collection = db.GetCollection<Cheers>("Cheers");
            var query = collection.AsQueryable<Cheers>();
            var result = query;


            int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            int pageSize = 6; //设置每页显示条数
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, result.Count());

            return View(result.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        public ActionResult Details(string id)
        {
            MongoDatabase db = Common.GetDatabase();
            var dataSet = db.GetCollection<Cheers>("Cheers").AsQueryable<Cheers>().OrderByDescending(i => i.date);
            Cheers cheers = null;
            int index = 0;
            foreach (var item in dataSet)
            {
                if (item.Id == id)
                {
                    cheers = item;
                    break;
                }
                index++;
            }

            //上一篇下一篇
            if (index != 0)
            {
                ViewBag.pre = dataSet.ElementAtOrDefault(index - 1);
            }
            if ((index + 1) != dataSet.Count())
            {
                ViewBag.next = dataSet.ElementAtOrDefault(index + 1);
            }
            return View(cheers);
        }

    }


}

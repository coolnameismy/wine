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


namespace WineWeb.Areas.Admin.Controllers
{
    public class ProductManageController : Controller
    {
        //
        // GET: /Admin/ProductManage/
        MongoDatabase db = Common.GetDatabase();

        public ActionResult Index()
        {
            var products = db.GetCollection<Product>("Product").AsQueryable<Product>();
            var result = products;

            int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            int pageSize = 15; //设置每页显示条数
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, result.Count());

            return View(result.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

    }
}

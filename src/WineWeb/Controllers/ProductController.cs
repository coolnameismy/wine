using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using WineWeb.BL;
using WineWeb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace WineWeb.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            MongoDatabase db = Common.GetDatabase();
            var products = db.GetCollection<Product>("Product").AsQueryable<Product>();
            var category = db.GetCollection<ProductCategory>("ProductCategory").AsQueryable<ProductCategory>().ToDictionary(i=>i.Id,i=>i.name);
            ViewBag.category = category;
            //int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            //int pageSize = 6; //设置每页显示条数
            //ViewBag.Pagination = new Pagination(pageIndex, pageSize, result.Count());

            //return View(result.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());
            return View(products.ToList());
        }
        public ActionResult List(string id)
        {
            MongoDatabase db = Common.GetDatabase();
            var products = db.GetCollection<Product>("Product").AsQueryable<Product>().Where(i=>i.categoryId == id);
            var category = db.GetCollection<ProductCategory>("ProductCategory").AsQueryable<ProductCategory>().ToList();

            int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            int pageSize = 15; //设置每页显示条数
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, products.Count());
            //分类名称
            ViewBag.CategoryName = category.FirstOrDefault(i => i.Id == id).name;
            return View(products.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
        public ActionResult Details(string id)
        {
            MongoDatabase db = Common.GetDatabase();
            var category = db.GetCollection<ProductCategory>("ProductCategory").AsQueryable<ProductCategory>().ToList();
            var product = db.GetCollection<Product>("Product").AsQueryable<Product>().Where(i=>i.Id==id).FirstOrDefault();
            //分类名称
            ViewBag.CategoryName = category.FirstOrDefault(i => i.Id == product.categoryId).name;
            return View(product);
        }
    }
}

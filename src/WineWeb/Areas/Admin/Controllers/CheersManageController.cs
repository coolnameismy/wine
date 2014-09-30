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
    public class CheersManageController : Controller
    {
        //
        // GET: /Admin/CheersManage/
        MongoDatabase db = Common.GetDatabase();

        public ActionResult Index()
        {
            var collection = db.GetCollection<Cheers>("Cheers");
            var query = collection.AsQueryable<Cheers>();
            var result = query;
            

            int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            int pageSize = 15; //设置每页显示条数
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, result.Count());

            return View(result.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/jjmcNewsCRUD/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Cheers add)
        {
            if (ModelState.IsValid)
            {
                var collection = db.GetCollection<Cheers>("Cheers");
                add.Id = Guid.NewGuid().ToString();
                //图片上传
                string image_Path = string.Empty;
                string _Path = "/Content/userfiles/Upload/";//设置上传路径
                HttpPostedFileBase image = Request.Files["thum"];
                image_Path = Liu_FileV1.SaveFile(image, Server.MapPath(_Path), _Path);
                add.thum = image_Path;
                add.date = DateTime.Now.AddHours(8);

                 var result = collection.Insert(add);
                return RedirectToAction("Index");
            }

            return View(add);
        }

        //
        // GET: /Admin/jjmcNewsCRUD/Edit/5

        public ActionResult Edit(string id)
        {
            var collection = db.GetCollection<Cheers>("Cheers");
            var query = Query<Cheers>.EQ(e => e.Id, id);
            var entity = collection.FindOne(query);

            if (entity == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Category = new SelectList(db.JNJNewsCategory, "Id", "Name", jnjnews.Category);
            return View(entity);
        }

        //
        // POST: /Admin/jjmcNewsCRUD/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Cheers cheers)
        {
            if (ModelState.IsValid)
            {
                var collection = db.GetCollection<Cheers>("Cheers");
                var query = Query<Cheers>.EQ(e => e.Id, cheers.Id);
                var entity = collection.FindOne(query);
                if (query == null)
                {
                    return HttpNotFound();
                }
                
                //图片上传
                string image_Path = string.Empty;
                string _Path = "/Content/userfiles/Upload/";//设置上传路径
                string date = Request.Form["DateTime"];
                cheers.date = Convert.ToDateTime(date).AddHours(8);
                HttpPostedFileBase image = Request.Files["thum"];
                image_Path = Liu_FileV1.SaveFile(image, Server.MapPath(_Path), _Path);
                if (!string.IsNullOrEmpty(image_Path))
                {
                    cheers.thum = image_Path;
                }

                entity = cheers;
                collection.Save(entity);

                return RedirectToAction("Index");
            }

            return View(cheers);
        }


        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var collection = db.GetCollection<Cheers>("Cheers");
            var query = Query<Cheers>.EQ(e => e.Id, id);
            var result = collection.Remove(query);
            return RedirectToAction("Index");
        }
        // 批量删除
        [HttpPost]
        public ActionResult BatchDelete()
        {

            var collection = db.GetCollection<Cheers>("Cheers");
            var query = collection.AsQueryable<Cheers>();
            var result = query;

            foreach (var item in result)
            {
                string deleteId = "delete_" + item.Id;
                if (Request.Form[deleteId] == "on")
                {
                    //删除
                   var del = Query<Cheers>.EQ(e => e.Id, item.Id);
                   collection.Remove(del);
                }
            }
 
            return RedirectToAction("index");

        }

        //搜索功能
        public ActionResult Search()
        {
            string Keyword = Request.QueryString["Keyword"];
            var collection = db.GetCollection<Cheers>("Cheers");
            var query = collection.AsQueryable<Cheers>().Where(i => i.title1.Contains(Keyword) || i.title2.Contains(Keyword) || i.content.Contains(Keyword));
            var result = query;


            int pageIndex = Request.QueryString["pageIndex"].QueryStringIntHelp();
            int pageSize = 15; //设置每页显示条数
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, result.Count());

            return View("Index", result.OrderByDescending(i => i.date).Skip(pageIndex * pageSize).Take(pageSize).ToList());



          

        }
    }
}

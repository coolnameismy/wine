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
    public class EncyclopediaManageController : Controller
    {
        //
        // GET: /Admin/EncyclopediaManage/
        MongoDatabase db = Common.GetDatabase();

        public ActionResult Index()
        {
            var collection = db.GetCollection<Encyclopedia>("Encyclopedia");
            var query = collection.AsQueryable<Encyclopedia>();
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
        public ActionResult Create(Encyclopedia add)
        {
            if (ModelState.IsValid)
            {

             
                var collection = db.GetCollection<Encyclopedia>("entities");
                collection.Insert(add);
                //图片上传
                string image_Path = string.Empty;
                string _Path = "/Content/userfiles/Upload/";//设置上传路径
                HttpPostedFileBase image = Request.Files["Upfile"];
                image_Path = Liu_FileV1.SaveFile(image, Server.MapPath(_Path), _Path);
                add.thum = image_Path;
                add.date = DateTime.Now;
         
                return RedirectToAction("Index");
            }

            return View(add);
        }

        //
        // GET: /Admin/jjmcNewsCRUD/Edit/5

        public ActionResult Edit(string id)
        {
            var collection = db.GetCollection<Encyclopedia>("entities");
            var query = Query<Encyclopedia>.EQ(e => e.Id, id);
            var entity = collection.FindOne(query);
            entity.title = "Title-Dick";
            collection.Save(entity);

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
        public ActionResult Edit(JNJNews jnjnews)
        {
            if (ModelState.IsValid)
            {
                var collection = db.GetCollection<Encyclopedia>("entities");
                var query = Query<Encyclopedia>.EQ(e => e.Id, id);
            //var update = Update<Entity>.Set(e => e.Name, "Harry"); // update modifiers
            //collection.Update(query, update);

                collection.Save(entity);

                if (entity == null)
                {
                    return HttpNotFound();
                }
                //ViewBag.Category = new SelectList(db.JNJNewsCategory, "Id", "Name", jnjnews.Category);
                return View(entity);


              
                //图片上传
                string image_Path = string.Empty;
                string _Path = "/Content/userfiles/Upload/";//设置上传路径
                string date = Request.Form["DateTime"];
                jnjnews.Date = Convert.ToDateTime(date);
                HttpPostedFileBase image = Request.Files["Upfile"];
                image_Path = Liu_FileV1.SaveFile(image, Server.MapPath(_Path), _Path);
                if (!string.IsNullOrEmpty(image_Path))
                {
                    jnjnews.Thum = image_Path;
                }
                //分类置顶新闻唯一，设置置顶新闻需先清空类表的置顶新闻
                if (jnjnews.IsCategoryTop)
                {
                    //判断设置置顶时，缩略图和导读是否为空
                    if (string.IsNullOrEmpty(jnjnews.SubTitle) || string.IsNullOrEmpty(jnjnews.Thum))
                    {
                        ModelState.AddModelError("", "设置置顶时，导读和缩略图不能为空。");
                        ViewBag.Category = new SelectList(db.JNJNewsCategory, "Id", "Name", jnjnews.Category);
                        return View(jnjnews);
                    }
                    var curTopNews = db.JNJNews.Where(i => i.Category == jnjnews.Category).Where(i => i.IsCategoryTop == true).ToList();
                    foreach (var item in curTopNews)
                    {
                        if (item != jnjnews)
                        {
                            item.IsCategoryTop = false;
                        }

                    }
                }


             


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Category = new SelectList(db.JNJNewsCategory, "Id", "Name", jnjnews.Category);
            return View(jnjnews);
        }

        //
        // GET: /Admin/jjmcNewsCRUD/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    JNJNews jnjnews = db.JNJNews.Find(id);
        //    if (jnjnews == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(jnjnews);
        //}

        ////
        // POST: /Admin/jjmcNewsCRUD/Delete/5

        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            JNJNews jnjnews = db.JNJNews.Find(id);
            db.JNJNews.Remove(jnjnews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

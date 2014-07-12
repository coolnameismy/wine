using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WineWeb.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //string strLine;
            //string result = "";
            //try
            //{

            //    FileStream aFile = new FileStream(Server.MapPath("//wine//index.html"), FileMode.Open);
            //    StreamReader sr = new StreamReader(aFile);
            //    result = sr.ReadToEnd();
                
            //    sr.Close();
            //}
            //catch (IOException ex)
            //{
            //    Response.Write("An IOException has been thrown!");
            //    Response.Write(ex.ToString());

            //}

            //Response.Write(result);

            Response.Redirect("/wine/index.html");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

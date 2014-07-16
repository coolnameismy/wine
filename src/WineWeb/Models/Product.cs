using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineWeb.BL;

namespace WineWeb.Models
{
    //葡萄酒
    public class Product
    {
        public string Id { get; set; }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string title3 { get; set; }
        public string thum { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public int index { get; set; }
        public string categoryId { get; set; }


        //视图字段
        public string ViewTitle3 {
            get {
                return Common.HandleStringLength(this.title3, 30);
            } 
        }
        public string Link
        {
            get { return "Product/Details/" + this.Id; }
        }
    }
}
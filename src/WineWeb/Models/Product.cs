using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineWeb.Models
{
    //葡萄酒
    public class Product
    {
        public string Id { get; set; }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string thum { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public int index { get; set; }
        public ProductCategory category { get; set; }
    }
}
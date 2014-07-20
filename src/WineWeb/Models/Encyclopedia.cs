using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineWeb.Models
{
    //酒事百科 
    public class Encyclopedia
    {
        private DateTime _date { get; set; }
        public string Id { get; set; }
        public string thum { get; set; }
        public DateTime date {
            get {
                return _date;
            }
            set {
                _date = value; 
            }
        }
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string content { get; set; }
        public string Link
        {
            get { return "Encyclopedia/Details/" + this.Id; }
        }
    }
}
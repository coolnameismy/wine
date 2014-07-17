﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineWeb.Models
{
    //酒事百科 
    public class Encyclopedia
    {
        public string Id { get; set; }
        public string thum { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string Link
        {
            get { return "Encyclopedia/Details/" + this.Id; }
        }
    }
}
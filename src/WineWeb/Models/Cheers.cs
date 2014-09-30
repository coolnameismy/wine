using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WineWeb.Models
{
    //酒事百科 
    public class Cheers
    {
        
        private DateTime _date { get; set; }

        //[Required(ErrorMessage = "必填字段")]
        public string Id { get; set; }

        //[Required(ErrorMessage = "必填字段")]
        public string thum { get; set; }

        [Required(ErrorMessage = "必填字段")]
        public DateTime date {
            get {
                return _date;
            }
            set {
                _date = value; 
            }
        }
        [Required(ErrorMessage = "必填字段")]
        [StringLength(50, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string title1 { get; set; }

        [Required(ErrorMessage = "必填字段")]
        [StringLength(250, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string title2 { get; set; }

        [Required(ErrorMessage = "必填字段")]
        [StringLength(5000, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string content { get; set; }

        public string Link
        {
            get { return "/Cheers/Details/" + this.Id; }
        }
    }
}
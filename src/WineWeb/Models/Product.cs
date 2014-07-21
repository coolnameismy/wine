using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineWeb.BL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
 
 
namespace WineWeb.Models
{
    //葡萄酒
    public class Product
    {
        public string Id { get; set; }

        [DisplayName("名称")]
        [Required(ErrorMessage = "必填字段")]
        [StringLength(50, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string title1 { get; set; }

        [DisplayName("附加名")]
        [Required(ErrorMessage = "必填字段")]
        [StringLength(50, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string title2 { get; set; }

        [DisplayName("导读")]
        [Required(ErrorMessage = "必填字段")]
        [StringLength(250, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string title3 { get; set; }

        [DisplayName("缩略图")]
        public string thum { get; set; }

        [DisplayName("内容")]
        [Required(ErrorMessage = "必填字段")]
        [StringLength(5000, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
        public string content { get; set; }

        [DisplayName("日期")]
        public DateTime date { get; set; }

        public int index { get; set; }

        [DisplayName("分类")]
        [Required(ErrorMessage = "必填字段")]
        [StringLength(50, ErrorMessage = "长度不能超过 {1} 个中文或英文字符。")]
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
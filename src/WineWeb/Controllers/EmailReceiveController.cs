using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WineWeb.Controllers
{
    public class EmailReceiveController : Controller
    {
        //
        // GET: /EmailReceive/
       [HttpPost]
        public void Index()
        {
            Message message = new Message();
            string name = Request.Form["name"];
            string gender = Request.Form["gender"];
            string company = Request.Form["company"];
            string address = Request.Form["address"];
            string tel1 = Request.Form["tel1"];
            string tel2 = Request.Form["tel2"];
            string tel3 = Request.Form["tel3"];
            string tel = tel1 + "-" + tel2 + "-" + tel3;
            string fax1 = Request.Form["fax1"];
            string fax2 = Request.Form["fax2"];
            string fax3 = Request.Form["fax3"];
            string fax = fax1 + "-" + fax2 + "-" + fax3;
            string phone = Request.Form["email"];
            string email = Request.Form["email"];
            string content = Request.Form["content"];

            //收件人
            string sendEmailTo = System.Configuration.ConfigurationManager.AppSettings["sendEmailTo"];
            string sendEmailTo1 = System.Configuration.ConfigurationManager.AppSettings["sendEmailTo1"];

            message = send(name, gender, company, address, tel, fax, phone, email, content, sendEmailTo);
            message = send(name, gender, company, address, tel, fax, phone, email, content, sendEmailTo1);

            Response.Redirect("/wine/contact_success.html");
        }
       public Message send(string name, string gender, string company, string address, string tel, string fax, string phone, string email, string content, string sendEmailTo)
       {

           Message message = new Message();

           if (string.IsNullOrEmpty(email))
           {
               message.Failure("email 地址不正确");
               return message;
           }

           try
           {
               string sendEmailFrom = System.Configuration.ConfigurationManager.AppSettings["sendEmailFrom"];
               string sendEmailFromPWD = System.Configuration.ConfigurationManager.AppSettings["sendEmailFromPWD"];
           

               System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(sendEmailFrom, "法酒社网站系统通知"); //填写电子邮件地址，和显示名称
               System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(sendEmailTo, "网站管理员"); //填写邮件的收件人地址和名称
               //设置好发送地址，和接收地址，接收地址可以是多个
               System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
               mail.From = from;
               mail.To.Add(to);
               mail.Subject = "法酒社web 网站用户反馈";
               mail.Body = " <h3>留言内容:</h3></br> " +
                             content + "</br> " +
                           "<h3>用户信息</h13></br> " +
                           "<p>称谓：" + name + " "+ gender +  "</p> </br> " +
                           "<p>公司：" + company + "</p></br> " +
                           "<p>地址：" + address + "</p></br> " +
                           "<p>电话：" + tel + "</p></br> " +
                           "<p>传真：" + fax + "</p></br> " +
                           "<p>手机：" + phone + "</p></br> " +
                           "<p>电子邮件：" + email + "</p></br> " +

                            "</br><h5>To ensure delivery to your inbox, please add " + sendEmailFrom + " to your address book. Please do not reply to this email, as we are unable to respond from this address.</h5>";

               mail.IsBodyHtml = true;//设置显示htmls
               //设置好发送邮件服务地址
               System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
               client.Host = "smtp.163.com";
               //填写服务器地址相关的用户名和密码信息
               client.Credentials = new System.Net.NetworkCredential(sendEmailFrom, sendEmailFromPWD);
               //发送邮件
               client.Send(mail);
           }
           catch
           {
               message.Failure("email send failure! some except has occur！");
               return message;
           }
           message.Succeed("Succeed");
           return message;

       }
    }
    
}

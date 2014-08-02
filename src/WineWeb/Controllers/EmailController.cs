using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WineWeb.Controllers
{
    public class EmailController : ApiController
    {
         [HttpGet]
        public string sendEmail1(){
            return "123";
         }
        [HttpPost]
        public void sendEmail()
        {
            Message message = new Message();
            var from = Request.Content.ReadAsFormDataAsync().Result;
            string name = from["name"];
            string company = from["company"];
            string address = from["address"];
            string tel1 = from["tel1"];
            string tel2 = from["tel2"];
            string tel3 = from["tel3"];
            string tel = tel1 + "-" + tel2 + "-" + tel3;
            string fax1 = from["fax1"];
            string fax2 = from["fax2"];
            string fax3 = from["fax3"];
            string fax = fax1 + "-" + fax2 + "-" + fax3;
            string phone = from["phone"];
            string email = from["email"];
            string content = from["content"];
            send(name, company, address, tel, fax, phone, email, content);
        }
        public Message send(string name, string company, string address, string tel, string fax, string phone, string email, string content)
        {

            Message message = new Message();

            if (string.IsNullOrEmpty(email))
            {
                message.Failure("email 地址不正确");
                return message;
            }

            try
            {
                System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress("collegife@163.com", "collegife System Notification"); //填写电子邮件地址，和显示名称

                System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress("coolnameismy@hotmail.com", "coolnameismy"); //填写邮件的收件人地址和名称
                //设置好发送地址，和接收地址，接收地址可以是多个
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = from;
                mail.To.Add(to);
                mail.Subject = "夏梦庄园web 网站用户反馈";
                mail.Body = " <h1>留言内容:</h1></br> " +
                              content + "</br> " +
                            "<h1>用户信息</h1></br> " +
                            "<h3>姓名：" + name + "</h3></br> " +
                            "<h3>公司：" + company + "</h3></br> " +
                            "<h3>地址：" + address + "</h3></br> " +
                            "<h3>电话：" + tel + "</h3></br> " +
                            "<h3>传真：" + fax + "</h3></br> " +
                            "<h3>手机：" + phone + "</h3></br> " +
                            "<h3>电子邮件：" + email + "</h3></br> " +
                        
                             "</br><h5>To ensure delivery to your inbox, please add collegife@163.com to your address book. Please do not reply to this email, as we are unable to respond from this address.</h5>";

                mail.IsBodyHtml = true;//设置显示htmls
                //设置好发送邮件服务地址
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.163.com";
                //填写服务器地址相关的用户名和密码信息
                client.Credentials = new System.Net.NetworkCredential("collegife@163.com", "collegife123456");
                //发送邮件
                client.Send(mail);
            }
            catch
            {
                message.Failure("email send failure! some except has occur！");
                return message;
            }
            message.Succeed("you passowrd has been send to you regist email address , please to check you email ");
            return message;

        }
    }
    public class Message
    {
        public Message()
        {
            this.msg = "";
            this.data = "";
            this.status = "0";
        }
        public Message(string status, string message, object data)
        {
            this.msg = message;
            this.data = data;
            this.status = status;
        }
        public Message(int status, string message, object data)
        {
            this.msg = message;
            this.data = data;
            this.status = status.ToString();
        }
        public string msg { get; set; }
        public object data { get; set; }
        public string status { get; set; }

        public bool IsSucceed()
        {
            if (this.status == "1") return true;
            else return false;
        }
        public void Succeed(string msg = "")
        {
            this.msg = msg;
            this.status = "1";
        }
        public void Succeed(object obj, string msg = "")
        {
            this.msg = msg;
            this.data = obj;
            this.status = "1";
        }
        public void Failure(string msg = "")
        {
            this.msg = msg;
            this.status = "0";
        }
    }
}

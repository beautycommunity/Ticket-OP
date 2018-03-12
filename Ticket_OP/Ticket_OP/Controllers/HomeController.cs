using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ticket_OP.Models;

namespace Ticket_OP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SandEmail()
        {
            

            return View();
        }

        public ActionResult success()
        {


            return View();
        }

        public ActionResult SandEmail_S(SandEmail mail)
        {
            GetEmail Email = new GetEmail();

            Email.FULLNAME = mail.FULLNAME;
            Email.EMAIL = mail.EMAIL;
            Email.PHONE = mail.PHONE;
            Email.MESSAGE = mail.MESSAGE;

            SendMail(Email);

            return RedirectToAction("success", "Home");
        }
        //SandEmail ticket, int mode = 0
        protected void SendMail(GetEmail Email)
        {
            string fnt1 = "<font size='5' face='Angsana New'>";
            string fnt2 = "</font>";
            //string url = global::System.Configuration.ConfigurationManager.AppSettings["Beauty.Host"].ToString();

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("itticket@beautycommunity.co.th", "International Business");

                mail.To.Add("OsContact@beautycommunity.co.th");
                mail.Subject = "Inquiry BeautyCommunity";

                //if (devdetail.EMAIL != null && devdetail.EMAIL.Length > 10)
                //{
                //    mail.To.Add(devdetail.EMAIL_CRE);
                //}
                //else{
                //    mail.Subject = "ปิด Ticket ! " + devdetail.TOPIC;
                //}

                mail.IsBodyHtml = true;
                StringBuilder sb = new StringBuilder();


                //url = url + "/Dev/DevDetail?DevId=" + devdetail.DV_ID.ToString();


                    sb.Append($"<br><b>{fnt1} มีผู้สมัครงานใหม่ !!{fnt2}</b><hr>");

                sb.Append($"<br><strong>{fnt1}ชื่อ-นามสกุล</strong> : {Email.FULLNAME}{fnt2}");//ชื่อ-นามสกุล
                sb.Append($"<br><strong>{fnt1}อีเมลติดต่อ</strong> : {Email.EMAIL}{fnt2}");//อีเมลติดต่อกลับ
                sb.Append($"<br><strong>{fnt1}เบอร์ต่อต่อ</strong> : {Email.PHONE}{fnt2}");//เบอร์ติดต่อ
                sb.Append($"<br><strong>{fnt1}รายละเอียด</strong> : {Email.MESSAGE}{fnt2}");//รายละเอียด


                mail.Body = sb.ToString();


                SmtpClient stmp = new SmtpClient();
                stmp.Send(mail);

                ViewBag.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
        }

        /*****************************************************************************************************/


        public ActionResult SandEmail_BCOM()
        {


            return View();
        }

        public ActionResult success_BCOM()
        {


            return View();
        }

        public ActionResult SandEmail_S_BCOM(SandEmail mail)
        {
            GetEmail Email = new GetEmail();

            Email.FULLNAME = mail.FULLNAME;
            Email.EMAIL = mail.EMAIL;
            Email.PHONE = mail.PHONE;
            Email.MESSAGE = mail.MESSAGE;

            SendMail_BCOM(Email);

            return RedirectToAction("success_BCOM", "Home");
        }
        //SandEmail ticket, int mode = 0
        protected void SendMail_BCOM(GetEmail Email)
        {
            string fnt1 = "<font size='5' face='Angsana New'>";
            string fnt2 = "</font>";
            //string url = global::System.Configuration.ConfigurationManager.AppSettings["Beauty.Host"].ToString();

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("OsContact@beautycommunity.co.th", "User");

                mail.To.Add("contact@beautycommunity.co.th");
                mail.Subject = "Information request from your website";

                //if (devdetail.EMAIL != null && devdetail.EMAIL.Length > 10)
                //{
                //    mail.To.Add(devdetail.EMAIL_CRE);
                //}
                //else{
                //    mail.Subject = "ปิด Ticket ! " + devdetail.TOPIC;
                //}

                mail.IsBodyHtml = true;
                StringBuilder sb = new StringBuilder();


                //url = url + "/Dev/DevDetail?DevId=" + devdetail.DV_ID.ToString();


                sb.Append($"<br><b>{fnt1} มีผู้สมัครงานใหม่ !!{fnt2}</b><hr>");

                sb.Append($"<br><strong>{fnt1}ชื่อ-นามสกุล</strong> : {Email.FULLNAME}{fnt2}");//ชื่อ-นามสกุล
                sb.Append($"<br><strong>{fnt1}อีเมลติดต่อ</strong> : {Email.EMAIL}{fnt2}");//อีเมลติดต่อกลับ
                sb.Append($"<br><strong>{fnt1}เบอร์ต่อต่อ</strong> : {Email.PHONE}{fnt2}");//เบอร์ติดต่อ
                sb.Append($"<br><strong>{fnt1}รายละเอียด</strong> : {Email.MESSAGE}{fnt2}");//รายละเอียด


                mail.Body = sb.ToString();


                SmtpClient stmp = new SmtpClient();
                stmp.Send(mail);

                ViewBag.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
        }
    }
}
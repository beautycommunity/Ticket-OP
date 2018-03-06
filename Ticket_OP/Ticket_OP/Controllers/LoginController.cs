using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_OP.DATA;
using Ticket_OP.Models;

namespace Ticket_OP.Controllers
{
    public class LoginController : Controller
    {
        string userOnline;
        string _POS;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            userOnline = GetCookie("1");
            _POS = "1";
            if (userOnline != string.Empty)
            {
                return RedirectToLocal(returnUrl,"1");
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login_Office(string returnUrl)
        {
            userOnline = GetCookie("0");
            _POS = "0";
            if (userOnline != string.Empty)
            {
                return RedirectToLocal(returnUrl,"0");
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login_Office(USER_LOGIN model, string returnUrl)
        {
            int LoginCase = 0;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (LoginBase(model,0))
            {
                LoginCase = 1;
            }


            switch (LoginCase)
            {
                case 1: // Complete Redirect
                    Session["User"] = model.STCODE;
                    TempData["User"] = model.STCODE;
                    SetCookie(model.STCODE,"0");
                    return RedirectToLocal(returnUrl,"0");
                case 2: //Lock out
                    return RedirectToAction("updatedid", model);
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }


        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USER_LOGIN model, string returnUrl)
        {
            int LoginCase = 0;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (LoginBase(model,1))
            {
                LoginCase = 1;
            }


            switch (LoginCase)
            {
                case 1: // Complete Redirect
                    Session["User"] = model.WHCODE;
                    TempData["User"] = model.WHCODE;
                    SetCookie(model.WHCODE,"1");
                    return RedirectToLocal(returnUrl,"1");
                case 2: //Lock out
                    return RedirectToAction("updatedid", model);
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        public bool LoginBase(USER_LOGIN model,int Position)
        {
            bool OK = false;

            Data_OPDataContext Context = new Data_OPDataContext();
            Data_UserDataContext Context_user = new Data_UserDataContext();

            if (Position == 1)
            {
                var queryX = Context.MAS_WHs.Where(x => x.WHCODE == model.WHCODE && x.WHCODE == model.PASSWORD).Count();

                if (queryX > 0)
                {

                    OK = true;
                }

            }
            else
            {
                var queryX = Context_user.MAS_USERs.Where(x => x.STCODE == model.STCODE && x.PASSWORD == model.PASSWORD).Count();

                if (queryX > 0)
                {

                    OK = true;
                }
            }

            return OK;
        }

        //public ActionResult updatedid(USER_LOGIN model)
        //{
        //    Dp_List ul = new Dp_List();
        //    Data_UserDataContext db = new Data_UserDataContext();

        //    ul.STCODE = model.STCODE;
        //    ul.JT_LIST = new SelectList(db.MAS_DEPs, "DP_ID", "DEPARTMENT");

        //    return View(ul);
        //}

        //[HttpPost]
        //public ActionResult updatedid(Dp_List model)
        //{
        //    using (Data_UserDataContext db = new Data_UserDataContext())
        //    {

        //        var q = (from pp in db.MAS_USERs
        //                 where pp.STCODE == model.STCODE
        //                 select pp).FirstOrDefault();

        //        q.D_ID = (int)model.JT_ID;

        //        db.SubmitChanges();

        //    }

        //    return RedirectToAction("Index", "Ticket");
        //}



        // GET:
        private ActionResult RedirectToLocal(string returnUrl,string Position)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "TicketOP", new { Pos = Position });
        }

        public bool chkSesionUser(string POS)
        {
            bool chk = true;

            userOnline = GetCookie(POS);
            

            if (userOnline == string.Empty)
            {
                try
                {
                    userOnline = Session["User"].ToString();
                    if (userOnline.Length < 1)
                    {
                        chk = false;
                    }
                }
                catch
                {
                    chk = false;
                }
            }

            using (Data_OPDataContext Context = new Data_OPDataContext())
            {
                try
                {
                    var sql = (from xx in Context.MAS_WHs
                               where xx.WHCODE == userOnline
                               select xx).FirstOrDefault();

                    if (sql != null)
                    {
                        Session["SharedName"] = "สวัสดี " + sql.FULLNAME;
                        Session["Name"] = sql.WHNAME;
                    }
                    else
                    {
                        Session["SharedName"] = "เข้าสู่ระบบ";
                    }
                }
                catch
                {
                    Session["SharedName"] = "เข้าสู่ระบบ";
                }
            }

            return chk;
        }

        private void SetCookie(string User,string POS)
        {

            //try
            //{
            //    Request.Cookies["bbWhcode"].Value = User;
            //}
            //catch
            //{
            //    HttpCookie BeautyCookies = new HttpCookie("bbWhcode");
            //    BeautyCookies.Value = User;
            //    BeautyCookies.Expires = DateTime.Now.AddDays(1);

            //    Response.Cookies.Add(BeautyCookies);
            //}

            if (POS == "0")
            {
                try
                {
                    Request.Cookies["bbStcode"].Value = User;
                }
                catch
                {
                    HttpCookie BeautyCookies = new HttpCookie("bbStcode");
                    BeautyCookies.Value = User;
                    BeautyCookies.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(BeautyCookies);
                }
            }
            else
            {
                try
                {
                    Request.Cookies["bbWhcode"].Value = User;
                }
                catch
                {
                    HttpCookie BeautyCookies = new HttpCookie("bbWhcode");
                    BeautyCookies.Value = User;
                    BeautyCookies.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(BeautyCookies);
                }
            }

            //Request.Cookies["bbStcode"].Value = User;   
        }


        private string GetCookie(string POS)
        {
            
            string cookievalue = string.Empty;

            if (POS == "1")
            {
                if (Request.Cookies["bbWhcode"] != null)
                {
                    cookievalue = Request.Cookies["bbWhcode"].Value.ToString();
                }
            }
            else
            {
                if (Request.Cookies["bbStcode"] != null)
                {
                    cookievalue = Request.Cookies["bbStcode"].Value.ToString();
                }
            }

            return cookievalue;
        }


        private void RemoveCookie(string POS)
        {
            if (POS == "0")
            {
                if (Request.Cookies["bbStcode"] != null)
                {
                    Response.Cookies["bbStcode"].Expires = DateTime.Now.AddDays(-1);
                }
            }
            else
            {
                if (Request.Cookies["bbWhcode"] != null)
                {
                    Response.Cookies["bbWhcode"].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }

        public ActionResult Logout()
        {
            try
            {

                Session["User"] = null;
                Session["DP"] = null;
                Session["SharedName"] = null;
                RemoveCookie("1");
            }
            catch
            {
                Session["User"] = "";
                Session["DP"] = "";
                Session["SharedName"] = "";
                RemoveCookie("1");

                return RedirectToAction("Login", "Login");
            }

            return RedirectToAction("Login", "Login");
        }

        public ActionResult Logout_Office()
        {
            try
            {

                Session["User"] = null;
                Session["DP"] = null;
                Session["SharedName"] = null;
                RemoveCookie("0");
            }
            catch
            {
                Session["User"] = "";
                Session["DP"] = "";
                Session["SharedName"] = "";
                RemoveCookie("0");

                return RedirectToAction("Login_Office", "Login");
            }

            return RedirectToAction("Login_Office", "Login");
        }
    }
}
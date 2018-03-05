using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket_OP.DATA;
using Ticket_OP.Models;

namespace Ticket_OP.Controllers
{
    public class TicketOPController : Controller
    {
        string userOnline;
        // GET: TicketBB
        public ActionResult Index(int page = 1)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/TicketOP/Index" }); }

            IQueryable<VW_TICKET> View_Ticket;

            Data_OPDataContext Context = new Data_OPDataContext();

            List<Ticket> lstTicket = new List<Ticket>();

            //string a = userOnline;
            var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            ViewBag.BRAND = queryX.BRAND;

            View_Ticket = Context.VW_TICKETs
                .Where(tik => tik.WHCODE == userOnline)
                .Where(tik => tik.FLAG == "0")
                .OrderBy(tik => tik.SS_ID);

            foreach (var ux in View_Ticket)
            {
                Ticket _ticket = new Ticket();

                _ticket.TK_ID = ux.TK_ID;
                _ticket.TICKETNO = ux.TICKETNO;
                _ticket.WHCODE = ux.WHCODE;
                _ticket.WHNAME = ux.WHNAME;
                _ticket.AREA = ux.AREA;
                _ticket.DETAIL = ux.DETAIL;
                _ticket.SS_ID = ux.SS_ID;
                _ticket.ST_NAME = ux.TNAME;
                _ticket.CREATEDATE = DateTime.Parse(ux.CREATEDATE.ToString()).ToShortDateString();
                _ticket.CREATETIME = ux.CREATETIME.ToString();

                lstTicket.Add(_ticket);
            }

            return View(lstTicket.ToPagedList(page, 10));
        }

        //Get : Create Ticket
        public ActionResult CreateTicket()
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/TicketOP/Index" }); }

            Data_OPDataContext Context = new Data_OPDataContext();

            //string a = userOnline;
            var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            //CreTicket newItem = new CreTicket();
            CreTicket newItem = new CreTicket();

            newItem.WHNAME = queryX.WHNAME;
            //newItem.US_ID = usr.Id;
            ViewBag.BRAND = queryX.BRAND;
            //newItem.JT_LIST = new SelectList(Context.MAS_JOB_TYPEs.Where(x => x.PROGRAM == "TICKET_IT"), "JT_ID", "JTNAME");

            var sql_AREA = (from xx in Context.MAS_AREAs
                            where xx.BRAND == queryX.BRAND
                            select xx).GroupBy(x => x.AREA).Select(grp => grp.First());

            newItem.AREA = new SelectList(sql_AREA, "AREA", "AREA");

            return View(newItem);
        }


        //POST: Create Ticket
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateTicket(CreTicket newItem)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/TicketOP/Index" }); }

            Ticket ticket = new Ticket();

            //OnUser usr = new OnUser();
            //usr = getUser(userOnline);

            using (Data_OPDataContext Context = new Data_OPDataContext())
            {
                var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
                var trnTicket = new TRN_TICKET();
                var trnTicket_f = new TRN_TICKET_F();
                //var TmpTicket = new TRN_TICKET_TMP();

                string tketNo = ticketNo(queryX.BRAND);

                trnTicket.TICKETNO = tketNo;
                trnTicket.WHCODE = userOnline;
                trnTicket.WHNAME = newItem.WHNAME;
                trnTicket.AREA = newItem.AREA_NAME;
                trnTicket.DETAIL = newItem.DETAIL;
                //trnTicket.JT_ID = newItem.JT_ID;
                trnTicket.SS_ID = 1;

                trnTicket.CREATEDATE = DateTime.Now;
                trnTicket.FLAG = "0";
                Context.TRN_TICKETs.InsertOnSubmit(trnTicket);

                //if (newItem.CN_ID != null && newItem.INFORMER != null)
                //{
                //    TmpTicket.TICKETNO = tketNo;
                //    TmpTicket.TOPIC = newItem.TOPIC;
                //    TmpTicket.DETAIL = newItem.DETAIL;
                //    TmpTicket.JT_ID = newItem.JT_ID;
                //    TmpTicket.DP_ID = newItem.DP_ID;
                //    TmpTicket.INFORMER = newItem.INFORMER;
                //    TmpTicket.CN_ID = newItem.CN_ID;
                //    TmpTicket.SS_ID = 1;
                //    TmpTicket.US_ID = newItem.US_ID;
                //    TmpTicket.CREATEDATE = DateTime.Now;
                //    Context.TRN_TICKET_TMPs.InsertOnSubmit(TmpTicket);
                //}

                Context.SubmitChanges();

                var Detail = Context.TRN_TICKETs.Where(s => s.TICKETNO == tketNo).FirstOrDefault();

                int tkId = Detail.TK_ID;
                Int16 oderNo = 0;
                string pathSet = "FilesUpload";

                if (Request.Files[0].ContentLength > 0)
                {
                    HttpPostedFileBase hpf_1 = Request.Files[0];
                    HttpPostedFileBase hpf_2 = Request.Files[1];
                    HttpPostedFileBase hpf_3 = Request.Files[2];

                    string fileName1 = "";
                    string fileName2 = "";
                    string fileName3 = "";
                    pathSet = "~/FilesUpload/";

                    if (hpf_1.FileName != null && hpf_1.FileName.Length > 0)
                    {
                        fileName1 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_1.FileName);
                        var path1 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName1);
                        hpf_1.SaveAs(path1);

                        fileName1 = pathSet + fileName1;
                    }

                    if (hpf_2.FileName != null && hpf_2.FileName.Length > 0)
                    {
                        fileName2 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_2.FileName);
                        var path2 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName2);
                        hpf_2.SaveAs(path2);

                        fileName2 = pathSet + fileName2;
                    }

                    if (hpf_3.FileName != null && hpf_3.FileName.Length > 0)
                    {
                        fileName3 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_3.FileName);
                        var path3 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName3);
                        hpf_3.SaveAs(path3);

                        fileName3 = pathSet + fileName3;
                    }

                    trnTicket_f.TK_ID = tkId;
                    trnTicket_f.ORDERNO = oderNo;
                    trnTicket_f.FILENO = 1;
                    trnTicket_f.PATH1 = fileName1;
                    trnTicket_f.PATH2 = fileName2;
                    trnTicket_f.PATH3 = fileName3;

                    Context.TRN_TICKET_Fs.InsertOnSubmit(trnTicket_f);
                    Context.SubmitChanges();
                }

                //SendMail(ticket);
            }

            return RedirectToAction("Index", "TicketOP");
        }

        public ActionResult TicketDetail(int TicketId)
        {
            IQueryable<VW_TICKET_DETAIL> View_Ticket;

            Data_OPDataContext Context = new Data_OPDataContext();

            List<Ticket> lstTicket = new List<Ticket>();
            AddComment addComment = new AddComment();
            //string a = userOnline;
            //var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            //ViewBag.BRAND = queryX.BRAND;

            View_Ticket = Context.VW_TICKET_DETAILs
                .Where(tik => tik.TK_ID == TicketId);

            foreach (var ux in View_Ticket)
            {
                Ticket _ticket = new Ticket();

                _ticket.TK_ID = ux.TK_ID;
                _ticket.TICKETNO = ux.TICKETNO;
                _ticket.WHCODE = ux.WHCODE;
                _ticket.WHNAME = ux.WHNAME;
                _ticket.AREA = ux.AREA;
                _ticket.DETAIL = ux.DETAIL;
                _ticket.SS_ID = ux.SS_ID;
                _ticket.ST_NAME = ux.TNAME;
                _ticket.CREATEDATE = DateTime.Parse(ux.CREATEDATE.ToString()).ToShortDateString();
                _ticket.CREATETIME = ux.CREATETIME.ToString();

                _ticket.ORDERNO = ux.ORDERNO;
                _ticket.TK_MESAGE = ux.TK_MESAGE;
                _ticket.US_ID = ux.US_ID;

                //_ticket.POS_NAME = ux.POS_NICKNAME;
                _ticket.POSTDATE = ux.DETAILDATE.ToString();


                lstTicket.Add(_ticket);
                addComment.TK_ID = ux.TK_ID;
                addComment.TICKETNO = ux.TICKETNO;
                addComment.SS_ID = ux.SS_ID;
            }
            addComment.ticket = lstTicket;

            return View(addComment);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult TicketDetail(AddComment commentItem)
        {          
            int oderNo = idOderno(commentItem.TK_ID);
            //OnUser usr = new OnUser();

            //usr = getUser(userOnline);

            using (Data_OPDataContext Context = new Data_OPDataContext())
            {

                var trnTicketI = new TRN_TICKET_I();

                trnTicketI.TK_ID = commentItem.TK_ID;
                trnTicketI.TK_MESAGE = commentItem.TK_MESAGE;
                trnTicketI.ORDERNO = (Int16)oderNo;
                //trnTicketI.US_ID = idUser(userOnline);
                trnTicketI.CREATEDATE = DateTime.Now;

                Context.TRN_TICKET_Is.InsertOnSubmit(trnTicketI);
                //Context.SubmitChanges();

                int tkId = commentItem.TK_ID;
                Context.SubmitChanges();
            }

            return RedirectToAction("TicketDetail", "TicketOP", new { TicketId = commentItem.TK_ID });
        }


        /*------------------------------------------------------------- Login ------------------------------------------------*/

        private string ticketNo(string Bread)
        {
            string runNo = Bread; 
            string strRun = "";
            string yy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            int intRun = 1;


            yy = yy.Substring(yy.Length - 2, 2);
            if (mm.Length == 1) { mm = "0" + mm; }

            runNo = runNo + yy + mm;

            using (Data_OPDataContext Context = new Data_OPDataContext())
            {
                try
                {
                    var queryX = Context.TRN_TICKETs.OrderByDescending(s => s.TICKETNO)
                    .Where(s => s.TICKETNO.Contains(runNo))
                    .FirstOrDefault();
                    strRun = queryX.TICKETNO;
                }
                catch
                {
                    strRun =  Bread +"18010000";
                }

            }

            strRun = strRun.Substring(strRun.Length - 4, 4);
            intRun = Int32.Parse(strRun);
            intRun = intRun + 1;

            strRun = intRun.ToString();

            switch (strRun.Length)
            {
                case 1:
                    strRun = "000" + strRun;
                    break;
                case 2:
                    strRun = "00" + strRun;
                    break;
                case 3:
                    strRun = "0" + strRun;
                    break;
            }

            runNo = runNo + strRun;

            return runNo;
        }

        private int idOderno(int tkId)
        {
            int id = 0;

            using (Data_OPDataContext searchContext = new Data_OPDataContext())
            {
                var queryX = searchContext.TRN_TICKET_Is.OrderByDescending(s => s.TK_ID)
                          .ThenByDescending(s => s.ORDERNO)
                          .Where(s => s.TK_ID == tkId)
                          .FirstOrDefault();

                try
                {
                    id = queryX.ORDERNO;
                    id = id + 1;
                }
                catch
                {
                    id = 1;
                }
            }

            return id;
        }

        public bool chkSesionUser()
        {
            bool chk = true;

            userOnline = GetCookie();

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

        private void SetCookie(string User)
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
            //Request.Cookies["bbStcode"].Value = User;   
        }

        private string GetCookie()
        {
            string cookievalue = string.Empty;

            if (Request.Cookies["bbStcode"] != null)
            {
                cookievalue = Request.Cookies["bbStcode"].Value.ToString();
            }

            return cookievalue;
        }

        private void RemoveCookie()
        {
            if (Request.Cookies["bbStcode"] != null)
            {
                Response.Cookies["bbStcode"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}
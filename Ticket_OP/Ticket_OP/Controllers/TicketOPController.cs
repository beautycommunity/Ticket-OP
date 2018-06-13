using Newtonsoft.Json;
using PagedList;
using RestSharp;
using RestSharp.Deserializers;
//using RestSharp;
//using RestSharp.Deserializers;
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
        string _POS;
        // GET: TicketBB
        public ActionResult Index(int page = 1,string Pos = "", string seach = "", string type = "")
        {
            if (!chkSesionUser(Pos)) { return RedirectToAction("Login", "Login", new { returnUrl = "~/TicketOP/Index" }); }

            Detail cc = new Detail();
            cc.Pos = Pos;
            cc.seach = seach;
            cc.type = type;
            cc.STCODE = userOnline;

            var restClient = new RestClient("http://http://5cosmeda.homeunix.com:89/Ticket_OP/api/TicketOP/Ticketlist");

            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(cc);
            var response = restClient.Execute(request);
            var json = response.Content;

            JsonDeserializer deserial = new JsonDeserializer();
            List<Ticket> item = JsonConvert.DeserializeObject<List<Ticket>>(json);
            //var ret = item.FirstOrDefault();
            //IQueryable<VW_TICKET> View_Ticket;

            //seach = seach.Trim();
            //type = type.Trim();

            Data_OPDataContext Context = new Data_OPDataContext();
            Data_UserDataContext C_user = new Data_UserDataContext();
            List<Ticket> lstTicket = new List<Ticket>();

            ViewBag.Type = new SelectList(Context.VW_TICKETs.GroupBy(x => x.TNAME).Select(grp => grp.First()), "TNAME", "TNAME");
            if (_POS == "1")
            {
                var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
                ViewBag.BRAND = queryX.BRAND;
            }
            else
            {
                var sql = C_user.VW_USER_ALLs.Where(x => x.STCODE == userOnline).FirstOrDefault();
                ViewBag.BRAND = sql.DPCODE;
            }

            //List<Ticket> lstTicket = new List<Ticket>();

            ////string a = userOnline;
            //if(_POS == "1")
            //{
            //    var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            //    ViewBag.BRAND = queryX.BRAND;

            //    View_Ticket = Context.VW_TICKETs
            //        .Where(tik => tik.WHCODE == userOnline)
            //        .Where(tik => tik.AREA.Contains(seach) || tik.WHNAME.Contains(seach) || tik.TICKETNO.Contains(seach))
            //        .Where(tik => tik.FLAG == "0")
            //        .OrderBy(tik => tik.SS_ID);
            //}
            //else
            //{
            //    var sql = C_user.VW_USER_ALLs.Where(x => x.STCODE == userOnline).FirstOrDefault();
            //    ViewBag.BRAND = sql.DPCODE;

            //    View_Ticket = Context.VW_TICKETs
            //        .Where(tik => tik.BRAND == sql.DPCODE)
            //        .Where(tik => tik.AREA.Contains(seach) || tik.WHNAME.Contains(seach) || tik.TICKETNO.Contains(seach))
            //        .Where(tik => tik.FLAG == "0")
            //        .OrderBy(tik => tik.SS_ID);
            //}

            //if (type != "")
            //{
            //    View_Ticket = View_Ticket.Where(tik => tik.TNAME == type);
            //}

            foreach (var ux in item)
            {
                Ticket _ticket = new Ticket();

                _ticket.TK_ID = ux.TK_ID;
                _ticket.TICKETNO = ux.TICKETNO;
                _ticket.WHCODE = ux.WHCODE;
                _ticket.WHNAME = ux.WHNAME;
                _ticket.AREA = ux.AREA;
                _ticket.DETAIL = ux.DETAIL;
                _ticket.SS_ID = ux.SS_ID;
                _ticket.ST_NAME = ux.ST_NAME;
                _ticket.REC_NICKNAME = ux.REC_NICKNAME;
                _ticket.CREATEDATE = DateTime.Parse(ux.CREATEDATE.ToString()).ToShortDateString();
                _ticket.CREATETIME = ux.CREATETIME.ToString();

                lstTicket.Add(_ticket);
            }

            ViewBag.Pos = _POS;
            ViewBag.WordSearch = seach;
            ViewBag.typeSearch = type;

            return View(lstTicket.ToPagedList(page, 10));
        }

        //Get : Create Ticket
        public ActionResult CreateTicket(string Pos = "1")
        {
            if (!chkSesionUser(Pos)) { return RedirectToAction("Login", "Login", new { returnUrl = "~/TicketOP/Index" }); }

            Data_OPDataContext Context = new Data_OPDataContext();

            //string a = userOnline;
            var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            //CreTicket newItem = new CreTicket();
            CreTicket newItem = new CreTicket();

            newItem.WHNAME = queryX.WHNAME;
            newItem.STCODE = userOnline;
            //newItem.US_ID = usr.Id;
            ViewBag.BRAND = queryX.BRAND;
            //newItem.JT_LIST = new SelectList(Context.MAS_JOB_TYPEs.Where(x => x.PROGRAM == "TICKET_IT"), "JT_ID", "JTNAME");

            var sql_AREA = (from xx in Context.MAS_AREAs
                            where xx.BRAND == queryX.BRAND
                            select xx).GroupBy(x => x.AREA).Select(grp => grp.First());

            newItem.AREA = new SelectList(sql_AREA, "AREA", "AREA");
            ViewBag.Pos = Pos;

            return View(newItem);
        }


        //POST: Create Ticket
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateTicket(CreTicket newItem,string Pos = "1")
        {
            if (!chkSesionUser(Pos)) { return RedirectToAction("Login", "Login", new { returnUrl = "~/TicketOP/Index" }); }

            var restClient = new RestClient("http://http://5cosmeda.homeunix.com:89/Ticket_OP/api/TicketOP/CreateTicket");

            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(newItem);
            var response = restClient.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            var messageList = deserial.Deserialize<List<RetApi>>(response);
            //var ret = messageList.FirstOrDefault();

            //if (ret.status == "S")
            //{

            //    ViewBag.userno = ret.USERNO;
            //    return View();

            //}
            //else
            //{
                string Posi = Pos;
                return RedirectToAction("Index", "TicketOP", new { Pos = Posi });
            //}
            //Ticket ticket = new Ticket();

            //using (Data_OPDataContext Context = new Data_OPDataContext())
            //{
            //    var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            //    var trnTicket = new TRN_TICKET();
            //    var trnTicket_f = new TRN_TICKET_F();
            //    //var TmpTicket = new TRN_TICKET_TMP();

            //    string tketNo = ticketNo(queryX.BRAND);

            //    trnTicket.TICKETNO = tketNo;
            //    trnTicket.WHCODE = userOnline;
            //    trnTicket.WHNAME = newItem.WHNAME;
            //    trnTicket.AREA = newItem.AREA_NAME;
            //    trnTicket.DETAIL = newItem.DETAIL;
            //    //trnTicket.JT_ID = newItem.JT_ID;
            //    trnTicket.SS_ID = 1;

            //    trnTicket.CREATEDATE = DateTime.Now;
            //    trnTicket.FLAG = "0";
            //    Context.TRN_TICKETs.InsertOnSubmit(trnTicket);

            //    Context.SubmitChanges();

            //    var Detail = Context.TRN_TICKETs.Where(s => s.TICKETNO == tketNo).FirstOrDefault();

            //    int tkId = Detail.TK_ID;
            //    Int16 oderNo = 0;
            //    string pathSet = "FilesUpload";

            //    if (Request.Files[0].ContentLength > 0)
            //    {
            //        HttpPostedFileBase hpf_1 = Request.Files[0];
            //        HttpPostedFileBase hpf_2 = Request.Files[1];
            //        HttpPostedFileBase hpf_3 = Request.Files[2];

            //        string fileName1 = "";
            //        string fileName2 = "";
            //        string fileName3 = "";
            //        pathSet = "~/FilesUpload/";

            //        if (hpf_1.FileName != null && hpf_1.FileName.Length > 0)
            //        {
            //            fileName1 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_1.FileName);
            //            var path1 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName1);
            //            hpf_1.SaveAs(path1);

            //            fileName1 = pathSet + fileName1;
            //        }

            //        if (hpf_2.FileName != null && hpf_2.FileName.Length > 0)
            //        {
            //            fileName2 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_2.FileName);
            //            var path2 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName2);
            //            hpf_2.SaveAs(path2);

            //            fileName2 = pathSet + fileName2;
            //        }

            //        if (hpf_3.FileName != null && hpf_3.FileName.Length > 0)
            //        {
            //            fileName3 = tketNo + "_" + tkId.ToString() + "_" + oderNo.ToString() + "_" + Path.GetFileName(hpf_3.FileName);
            //            var path3 = Path.Combine(Server.MapPath("~/FilesUpload"), fileName3);
            //            hpf_3.SaveAs(path3);

            //            fileName3 = pathSet + fileName3;
            //        }

            //        trnTicket_f.TK_ID = tkId;
            //        trnTicket_f.ORDERNO = oderNo;
            //        trnTicket_f.FILENO = 1;
            //        trnTicket_f.PATH1 = fileName1;
            //        trnTicket_f.PATH2 = fileName2;
            //        trnTicket_f.PATH3 = fileName3;

            //        Context.TRN_TICKET_Fs.InsertOnSubmit(trnTicket_f);
            //        Context.SubmitChanges();
            //    }
            //}
        }

        public ActionResult TicketDetail(int TicketId, string Pos)
        {
            Detail cc = new Detail();
            cc.Ticket_ID = TicketId;

            var restClient = new RestClient("http://http://5cosmeda.homeunix.com:89/Ticket_OP/api/TicketOP/TicketDetail");

            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(cc);
            var response = restClient.Execute(request);
            var json = response.Content;

            JsonDeserializer deserial = new JsonDeserializer();
            List<AddComment> item = JsonConvert.DeserializeObject<List<AddComment>>(json);
            var ret = item.FirstOrDefault();

            //------------------------------------------

            //IQueryable<VW_TICKET_DETAIL> View_Ticket;

            //Data_OPDataContext Context = new Data_OPDataContext();

            //List<Ticket> lstTicket = new List<Ticket>();
            //AddComment addComment = new AddComment();
            ////string a = userOnline;
            ////var queryX = Context.MAS_WHs.Where(x => x.WHCODE == userOnline).FirstOrDefault();
            ////ViewBag.BRAND = queryX.BRAND;

            //View_Ticket = Context.VW_TICKET_DETAILs
            //    .Where(tik => tik.TK_ID == TicketId);
            AddComment addComment = new AddComment();
            //IQueryable<VW_TICKET_DETAIL> View_Ticket;
            List<Ticket> lstTicket = new List<Ticket>();

            foreach (var ux in ret.ticket)
            {
                Ticket _ticket = new Ticket();
                               
                _ticket.TK_ID = ux.TK_ID;
                _ticket.TICKETNO = ux.TICKETNO;
                _ticket.WHCODE = ux.WHCODE;
                _ticket.WHNAME = ux.WHNAME;
                _ticket.AREA = ux.AREA;
                _ticket.DETAIL = ux.DETAIL;
                _ticket.SS_ID = ux.SS_ID;
                _ticket.ST_NAME = ux.ST_NAME;
                _ticket.CREATEDATE = DateTime.Parse(ux.CREATEDATE.ToString()).ToShortDateString();
                _ticket.CREATETIME = ux.CREATETIME.ToString();
                _ticket.REC_NICKNAME = ux.REC_NICKNAME;

                _ticket.ORDERNO = ux.ORDERNO;
                _ticket.TK_MESAGE = ux.TK_MESAGE;
                //_ticket.US_ID = ux.Expr1;

                //_ticket.POS_NAME = ux.POS_NICKNAME;
                //_ticket.POSTDATE = ux.DETAILDATE.ToString();

                //_ticket.FLS = flsPath(ux.TK_ID, 1);
                //_ticket.FLS_I = flsPath(ux.TK_ID, 1, (Int16)ux.ORDERNO);
                //_ticket.FLS_H_1 = flsPath(ux.TK_ID, 1);
                //_ticket.FLS_H_2 = flsPath(ux.TK_ID, 2);
                //_ticket.FLS_H_3 = flsPath(ux.TK_ID, 3);

                //try
                //{
                //    _ticket.FLS_H_1_Name = _ticket.FLS_H_1.Substring(14, _ticket.FLS_H_1.Length - 14);
                //    String[] substrings_1 = _ticket.FLS_H_1.Split('.');
                //    int num_1 = substrings_1.Length;
                //    string check_1 = substrings_1[num_1 - 1];
                //    var sql_1 = (from xx in Context.DEV_TASK_FLAGs
                //                 where xx.Type_name == check_1
                //                 select xx).FirstOrDefault();
                //    if (sql_1.FLAG == 1)
                //    {
                //        _ticket.FLAG_1 = "1";
                //    }
                //    else
                //    {
                //        _ticket.FLAG_1 = "2";
                //        _ticket.IMG_1 = sql_1.File_img;
                //    }

                //    _ticket.FLS_H_2_Name = _ticket.FLS_H_2.Substring(14, _ticket.FLS_H_2.Length - 14);
                //    String[] substrings_2 = _ticket.FLS_H_2.Split('.');
                //    int num_2 = substrings_2.Length;
                //    string check_2 = substrings_2[num_2 - 1];
                //    var sql_2 = (from xx in Context.DEV_TASK_FLAGs
                //                 where xx.Type_name == check_2
                //                 select xx).FirstOrDefault();
                //    if (sql_2.FLAG == 1)
                //    {
                //        _ticket.FLAG_2 = "1";
                //    }
                //    else
                //    {
                //        _ticket.FLAG_2 = "2";
                //        _ticket.IMG_2 = sql_2.File_img;
                //    }

                //    _ticket.FLS_H_3_Name = _ticket.FLS_H_3.Substring(14, _ticket.FLS_H_3.Length - 14);
                //    String[] substrings_3 = _ticket.FLS_H_3.Split('.');
                //    int num_3 = substrings_3.Length;
                //    string check_3 = substrings_3[num_3 - 1];
                //    var sql_3 = (from xx in Context.DEV_TASK_FLAGs
                //                 where xx.Type_name == check_3
                //                 select xx).FirstOrDefault();
                //    if (sql_3.FLAG == 1)
                //    {
                //        _ticket.FLAG_3 = "1";
                //    }
                //    else
                //    {
                //        _ticket.FLAG_3 = "2";
                //        _ticket.IMG_3 = sql_3.File_img;
                //    }
                //}
                //catch
                //{

                //}


                lstTicket.Add(_ticket);
                addComment.TK_ID = ux.TK_ID;
                addComment.TICKETNO = ux.TICKETNO;
                addComment.SS_ID = ux.SS_ID;
            }
            addComment.ticket = lstTicket;
            ViewBag.Pos = Pos;

            return View(addComment);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult TicketDetail(AddComment commentItem)
        {
            if (!chkSesionUser("0")) { return RedirectToAction("Login", "Login_Office", new { returnUrl = "~/TicketOP/Index" }); }

            var restClient = new RestClient("http://http://5cosmeda.homeunix.com:89/Ticket_OP/api/TicketOP/TicketComment");

            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(commentItem);
            var response = restClient.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            var messageList = deserial.Deserialize<List<RetApi>>(response);
            //int oderNo = idOderno(commentItem.TK_ID);

            //using (Data_OPDataContext Context = new Data_OPDataContext())
            //{
            //    var trnTicketI = new TRN_TICKET_I();

            //    trnTicketI.TK_ID = commentItem.TK_ID;
            //    trnTicketI.TK_MESAGE = commentItem.TK_MESAGE;
            //    trnTicketI.ORDERNO = (Int16)oderNo;
            //    //trnTicketI.US_ID = idUser(userOnline);
            //    trnTicketI.CREATEDATE = DateTime.Now;
            //    trnTicketI.STCODE = userOnline; 

            //    Context.TRN_TICKET_Is.InsertOnSubmit(trnTicketI);
            //    //Context.SubmitChanges();

            //    int tkId = commentItem.TK_ID;
            //    Context.SubmitChanges();
            //}

            return RedirectToAction("TicketDetail", "TicketOP", new { TicketId = commentItem.TK_ID, Pos = "0" });
        }

        public ActionResult TicketReceive(int TicketId)
        {
            if (!chkSesionUser("0")) { return RedirectToAction("Login", "Login_Office", new { returnUrl = "~/TicketOP/Index" }); }

            using (Data_OPDataContext Context = new Data_OPDataContext())
            {

                var sql = (from xx in Context.TRN_TICKETs
                           where xx.TK_ID == TicketId
                           select xx).FirstOrDefault();

                sql.STCODE = userOnline;
                sql.SS_ID = 2;

                Context.SubmitChanges();
            }

            return RedirectToAction("TicketDetail", "TicketOP", new { TicketId = TicketId, Pos = "0" });
        }

        public ActionResult TicketClose(int TicketId, string Pos)
        {

            using (Data_OPDataContext Context = new Data_OPDataContext())
            {

                var sql = (from xx in Context.TRN_TICKETs
                           where xx.TK_ID == TicketId
                           select xx).FirstOrDefault();

                //sql.STCODE = userOnline;
                sql.SS_ID = 3;

                Context.SubmitChanges();
            }

            return RedirectToAction("TicketDetail", "TicketOP", new { TicketId = TicketId, Pos = Pos });
        }


        /*------------------------------------------------------------- Funtion ------------------------------------------------*/

        private string flsPath(int tkId, int atFilePosition, Int16 odr = 0)
        {
            string path = "";

            using (Data_OPDataContext searchContext = new Data_OPDataContext())
            {
                var queryX = searchContext.TRN_TICKET_Fs
                          .Where(s => s.TK_ID == tkId && s.ORDERNO == odr)
                          .FirstOrDefault();

                switch (atFilePosition)
                {
                    case 1:
                        try
                        {
                            path = queryX.PATH1;
                        }
                        catch
                        {
                            path = "";
                        }
                        break;
                    case 2:
                        try
                        {
                            path = queryX.PATH2;
                        }
                        catch
                        {
                            path = "";
                        }
                        break;
                    case 3:
                        try
                        {
                            path = queryX.PATH3;
                        }
                        catch
                        {
                            path = "";
                        }
                        break;
                    default:
                        break;
                }

            }

            return path;
        }

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

        /*------------------------------------------------------------- Login ------------------------------------------------*/

        public bool chkSesionUser(string Pos)
        {
            bool chk = true;

            userOnline = GetCookie(Pos);
            _POS = Pos;

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

            if(Pos == "1")
            {
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
                            Session["POS"] = "1";
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
            }else if(Pos == "0")
            {
                using (Data_UserDataContext Context = new Data_UserDataContext())
                {
                    try
                    {
                        var sql = (from xx in Context.MAS_USERs
                                   where xx.STCODE == userOnline
                                   select xx).FirstOrDefault();

                        if (sql != null)
                        {
                            Session["SharedName"] = "สวัสดี " + sql.FNAME;
                            Session["Name"] = sql.FNAME;
                            Session["POS"] = "0";
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
            }

            return chk;
        }

        private void SetCookie(string User)
        {

            try
            {
                Request.Cookies["bbWhcode"].Value = User;
            }
            catch
            {
                System.Web.HttpCookie BeautyCookies = new System.Web.HttpCookie("bbWhcode");
                BeautyCookies.Value = User;
                BeautyCookies.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(BeautyCookies);
            }

            //if (_POS == "0")
            //{
            //    try
            //    {
            //        Request.Cookies["bbStcode"].Value = User;
            //    }
            //    catch
            //    {
            //        HttpCookie BeautyCookies = new HttpCookie("bbStcode");
            //        BeautyCookies.Value = User;
            //        BeautyCookies.Expires = DateTime.Now.AddDays(1);

            //        Response.Cookies.Add(BeautyCookies);
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        Request.Cookies["bbWhcode"].Value = User;
            //    }
            //    catch
            //    {
            //        HttpCookie BeautyCookies = new HttpCookie("bbWhcode");
            //        BeautyCookies.Value = User;
            //        BeautyCookies.Expires = DateTime.Now.AddDays(1);

            //        Response.Cookies.Add(BeautyCookies);
            //    }
            //}
            //Request.Cookies["bbStcode"].Value = User;   
        }

        private string GetCookie(string POS)
        {
            string cookievalue = string.Empty;

            //if (Request.Cookies["bbWhcode"] != null)
            //{
            //    cookievalue = Request.Cookies["bbWhcode"].Value.ToString();
            //}

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

        private void RemoveCookie()
        {
            if (Request.Cookies["bbStcode"] != null)
            {
                Response.Cookies["bbStcode"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}
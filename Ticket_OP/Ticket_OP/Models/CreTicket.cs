using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticket_OP.Models
{
    public class CreTicket
    {
        public int TK_ID { get; set; }

        [Display(Name = "เลขที่")]
        public string TICKETNO { get; set; }

        [Required(ErrorMessage = "กรุณาใส่หัวข้อด้วยครับ")]
        [Display(Name = "หัวข้อ")]

        public string TOPIC { get; set; }

        [Required(ErrorMessage = "กรุณาใส่รายละเอียดด้วยครับ")]
        [Display(Name = "รายละเอียด")]
        public string DETAIL { get; set; }

        public int? SS_ID { get; set; }
        [Display(Name = "สถานะ")]
        public string ST_NAME { get; set; }

        [Required(ErrorMessage = "กรุณาเลือกประเภทงาน")]
        public int? JT_ID { get; set; }

        [Display(Name = "ประเภทงาน")]
        public string JT_NAME { get; set; }

        public int? US_ID { get; set; }
        //[Display(Name = "ผู้แจ้ง")]
        //public string CRE_NAME { get; set; }

        [Display(Name = "ผู้แจ้ง")]
        public string CRE_NICKNAME { get; set; }

        [Display(Name = "วันที่แจ้ง")]
        public string CREATEDATE { get; set; }

        public string SOLUTION { get; set; }

        public SelectList DP_LIST { get; set; }
        public int? DP_ID { get; set; }
        public SelectList CN_LIST { get; set; }
        public int? CN_ID { get; set; }
        public string INFORMER { get; set; }


        public string WHNAME { get; set; }


        public SelectList AREA { get; set; }

        [Required(ErrorMessage = "กรุณาเลือกแอเรียด้วยครับ")]
        public string AREA_NAME { get; set; }

        public IEnumerable<HttpPostedFileBase> file { get; set; }
    }

    public class Ticket
    {
        public int TK_ID { get; set; }

        [Display(Name = "เลขที่")]
        public string TICKETNO { get; set; }

        [Display(Name = "รายละเอียด")]
        public string DETAIL { get; set; }

        public int? SS_ID { get; set; }
        [Display(Name = "สถานะ")]
        public string ST_NAME { get; set; }

        //public SelectList JT_LIST { get; set; }
        //public int? JT_ID { get; set; }
        //[Display(Name = "ประเภทงาน")]
        //public string JT_NAME { get; set; }

        //public int? US_ID { get; set; }
        //[Display(Name = "ผู้แจ้ง")]
        //public string CRE_NAME { get; set; }

        //[Display(Name = "ผู้แจ้ง")]
        //public string CRE_NICKNAME { get; set; }

        //[Display(Name = "E-Mail")]
        //public string EMAIL { get; set; }

        [Display(Name = "วันที่")]
        public string CREATEDATE { get; set; }

        [Display(Name = "เวลา")]
        public string CREATETIME { get; set; }

        [Display(Name = "รหัสสาขา")]
        public string WHCODE { get; set; }

        [Display(Name = "ชื่อสาขา")]
        public string WHNAME { get; set; }

        [Display(Name = "แอเรีย")]
        public string AREA { get; set; }

        //public string SOLUTION { get; set; }

        //public int? RECEIVE_ID { get; set; }

        //[Display(Name = "ผู้รับ")]
        //public string REC_NICKNAME { get; set; }

        //public string RECEIVEDATE { get; set; }

        //public int? R_DIFF { get; set; }

        //public string CLOSEDDATE { get; set; }

        //public int? C_DIFF { get; set; }

        //public int? J_DIFF { get; set; }

        //[Display(Name = "ผู้ปิด")]
        //public string CLS_NAME { get; set; }

        //public int? Rating { get; set; }

        //[Display(Name = "คอมเม้น : ")]
        //public string Message { get; set; }
    }

}
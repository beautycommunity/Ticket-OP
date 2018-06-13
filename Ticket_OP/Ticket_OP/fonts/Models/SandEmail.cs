using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticket_OP.Models
{
    public class SandEmail
    {
        //public SelectList JT_LIST { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ชื่อนามสกุล")]
        [Display(Name = "ชื่อ-นามสกุล")]
        public string FULLNAME { get; set; }

        [Required(ErrorMessage = "กรุณาใส่อีเมล")]
        [Display(Name = "อีเมล")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "กรุณาใส่เบอร์ติดต่อ")]
        [Display(Name = "เบอร์ติดต่อ")]
        public string PHONE { get; set; }

        [Required(ErrorMessage = "กรุณาใส่รายละเอียด")]
        [Display(Name = "รายละเอียด")]
        public string MESSAGE { get; set; }

    }

    public class GetEmail
    {
        //public SelectList JT_LIST { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ชื่อนามสกุล")]
        [Display(Name = "ชื่อ-นามสกุล")]
        public string FULLNAME { get; set; }

        [Required(ErrorMessage = "กรุณาใส่อีเมล")]
        [Display(Name = "อีเมล")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "กรุณาใส่เบอร์ติดต่อ")]
        [Display(Name = "เบอร์ติดต่อ")]
        public string PHONE { get; set; }

        [Required(ErrorMessage = "กรุณาใส่รายละเอียด")]
        [Display(Name = "รายละเอียด")]
        public string MESSAGE { get; set; }

    }
}
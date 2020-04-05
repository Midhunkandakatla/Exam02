using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kandakatla_Exam_02.Models
{
    public class Payment
    {
        public int PatientID { get; set; }
        public int InsuranceID { get; set; }
        public int PaymentID { get; set; }

        public int Amount { get; set; }


        public virtual Patient Patient { get; set; }
        public virtual Insurance Insurance { get; set; }
    }
}
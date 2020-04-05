using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kandakatla_Exam_02.Models
{
    public class Insurance
    {
        public int InsuranceID { get; set; }
        public string InsuranceName { get; set; }
        public int InsurancePhoneNumber { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
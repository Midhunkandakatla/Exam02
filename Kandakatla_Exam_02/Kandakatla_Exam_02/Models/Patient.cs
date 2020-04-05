using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kandakatla_Exam_02.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public string State { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }
    }
}
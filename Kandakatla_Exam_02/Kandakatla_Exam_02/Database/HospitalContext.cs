using Kandakatla_Exam_02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Kandakatla_Exam_02.Database
{
    public class HospitalContext : DbContext
    {

        public HospitalContext() : base("HospitalContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
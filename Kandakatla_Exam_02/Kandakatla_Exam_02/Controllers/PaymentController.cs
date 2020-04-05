using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kandakatla_Exam_02.Database;
using Kandakatla_Exam_02.Models;

namespace Kandakatla_Exam_02.Controllers
{
    public class PaymentController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Payment
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Insurance).Include(p => p.Patient);
            return View(payments.ToList());
        }

        // GET: Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "Name");
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,PatientID,InsuranceID,Amount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", payment.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "Name", payment.PatientID);
            return View(payment);
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", payment.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "Name", payment.PatientID);
            return View(payment);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,PatientID,InsuranceID,Amount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "InsuranceName", payment.InsuranceID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "Name", payment.PatientID);
            return View(payment);
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

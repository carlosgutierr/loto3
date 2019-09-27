using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewLottoApp2019.Models;

namespace NewLottoApp2019.Controllers
{
    public class lottoHistoriesController : Controller
    {
        private Lotto2019Pic3Entities db = new Lotto2019Pic3Entities();

        // GET: lottoHistories
        public ActionResult Index(DateTime? start, DateTime? end, int? pick1, int? pick2, int? pick3)
        {


            var data = (from u in db.lottoHistories
                        where u.Date > start && u.Date < end && u.Pk1 == pick1.ToString() && u.Pk2 == pick2.ToString() && u.Pk3 == pick3.ToString()
                        select u).ToList();
            return View(data);


        }

        // GET: lottoHistories/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lottoHistory lottoHistory = db.lottoHistories.Find(id);
            if (lottoHistory == null)
            {
                return HttpNotFound();
            }
            return View(lottoHistory);
        }

        // GET: lottoHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lottoHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,Mid_Day,Pk1,Pk2,Pk3")] lottoHistory lottoHistory)
        {
            if (ModelState.IsValid)
            {
                db.lottoHistories.Add(lottoHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lottoHistory);
        }

        // GET: lottoHistories/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lottoHistory lottoHistory = db.lottoHistories.Find(id);
            if (lottoHistory == null)
            {
                return HttpNotFound();
            }
            return View(lottoHistory);
        }

        // POST: lottoHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,Mid_Day,Pk1,Pk2,Pk3")] lottoHistory lottoHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lottoHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lottoHistory);
        }

        // GET: lottoHistories/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lottoHistory lottoHistory = db.lottoHistories.Find(id);
            if (lottoHistory == null)
            {
                return HttpNotFound();
            }
            return View(lottoHistory);
        }

        // POST: lottoHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            lottoHistory lottoHistory = db.lottoHistories.Find(id);
            db.lottoHistories.Remove(lottoHistory);
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

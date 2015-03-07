using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NFCTagLocator.Models;

namespace NFCTagLocator.Controllers
{
    public class NFCsController : Controller
    {
        private NFCDBContext db = new NFCDBContext();

        // GET: NFCs
        public ActionResult Index()
        {
            return View(db.NFCs.ToList());
        }

        // GET: NFCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFC nFC = db.NFCs.Find(id);
            if (nFC == null)
            {
                return HttpNotFound();
            }
            return View(nFC);
        }

        // GET: NFCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NFCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName")] NFC nFC)
        {
            if (ModelState.IsValid)
            {
                db.NFCs.Add(nFC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nFC);
        }

        // GET: NFCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFC nFC = db.NFCs.Find(id);
            if (nFC == null)
            {
                return HttpNotFound();
            }
            return View(nFC);
        }

        // POST: NFCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName")] NFC nFC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nFC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nFC);
        }

        // GET: NFCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NFC nFC = db.NFCs.Find(id);
            if (nFC == null)
            {
                return HttpNotFound();
            }
            return View(nFC);
        }

        // POST: NFCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NFC nFC = db.NFCs.Find(id);
            db.NFCs.Remove(nFC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LocateTag()
        {
            ViewBag.Message = "LocateTag";

            return View();
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

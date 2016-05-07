using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class MathTaskTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MathTaskTypes
        public ActionResult Index()
        {
            return View(db.MathTaskTypes.ToList());
        }

        // GET: MathTaskTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathTaskType mathTaskType = db.MathTaskTypes.Find(id);
            if (mathTaskType == null)
            {
                return HttpNotFound();
            }
            return View(mathTaskType);
        }

        // GET: MathTaskTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MathTaskTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MathTaskType mathTaskType)
        {
            if (ModelState.IsValid)
            {
                db.MathTaskTypes.Add(mathTaskType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mathTaskType);
        }

        // GET: MathTaskTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathTaskType mathTaskType = db.MathTaskTypes.Find(id);
            if (mathTaskType == null)
            {
                return HttpNotFound();
            }
            return View(mathTaskType);
        }

        // POST: MathTaskTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MathTaskType mathTaskType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mathTaskType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mathTaskType);
        }

        // GET: MathTaskTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathTaskType mathTaskType = db.MathTaskTypes.Find(id);
            if (mathTaskType == null)
            {
                return HttpNotFound();
            }
            return View(mathTaskType);
        }

        // POST: MathTaskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MathTaskType mathTaskType = db.MathTaskTypes.Find(id);
            db.MathTaskTypes.Remove(mathTaskType);
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

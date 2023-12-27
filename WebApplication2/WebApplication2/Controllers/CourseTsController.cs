using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CourseTsController : Controller
    {
        private CrudopEntities1 db = new CrudopEntities1();

        // GET: CourseTs
        public ActionResult Index()
        {
            ViewBag.num = db.CourseTs.Count();
            ViewBag.tech=db.CourseTs.Select(x=>x.Technology).ToList();
            ViewData["msg"] ="Welcome to Our Courses";
            return View(db.CourseTs.ToList());
        }

        // GET: CourseTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseT courseT = db.CourseTs.Find(id);
            if (courseT == null)
            {
                return HttpNotFound();
            }
            return View(courseT);
        }

        // GET: CourseTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CId,CName,CFee,Status,Technology")] CourseT courseT)
        {
            if (ModelState.IsValid)
            {
                db.CourseTs.Add(courseT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseT);
        }

        // GET: CourseTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseT courseT = db.CourseTs.Find(id);
            if (courseT == null)
            {
                return HttpNotFound();
            }
            return View(courseT);
        }

        // POST: CourseTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CId,CName,CFee,Status,Technology")] CourseT courseT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseT);
        }

        // GET: CourseTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseT courseT = db.CourseTs.Find(id);
            if (courseT == null)
            {
                return HttpNotFound();
            }
            return View(courseT);
        }

        // POST: CourseTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseT courseT = db.CourseTs.Find(id);
            db.CourseTs.Remove(courseT);
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

using SRAD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SRAD_MVC.Controllers
{
    public class GradeController : Controller
    {
        private MainContext db = new MainContext();
        // GET: Grade
        public ActionResult Index()
        {
            var Model = db.User.Where(d => d.UserType == "Student").ToList();
            return View(Model);
        }
        public ActionResult Manage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            var Model = db.Grade.Where(d => d.User == user.UserName).ToList();
            ViewBag.Id = id;
            ViewBag.UserName = db.User.Where(d => d.Id == id).Select(s=>s.UserName).FirstOrDefault();
            return View(Model);
        }
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            ViewBag.UserName = db.User.Where(d => d.Id == id).Select(s => s.UserName).FirstOrDefault();
            List<SelectListItem> courseList = new List<SelectListItem>();
            foreach (var item in db.Course.ToList())
            {
                courseList.Add(new SelectListItem()
                {
                    Value = item.Name,
                    Text = item.Name
                });
            }
            ViewBag.courseList = courseList;
            Grade grade = new Grade();
            grade.User = ViewBag.UserName;
            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Course,Score")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Grade.Add(grade);
                db.SaveChanges();
                var Id = db.User.Where(d => d.UserName == grade.User).Select(s => s.Id).FirstOrDefault();
                return RedirectToAction("Manage", new { Id = Id });
            }

            return View(grade);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ViewBag.Id = id;
            ViewBag.UserName = db.User.Where(d => d.Id == id).Select(s => s.UserName).FirstOrDefault();
            List<SelectListItem> courseList = new List<SelectListItem>();
            foreach (var item in db.Course.ToList())
            {
                courseList.Add(new SelectListItem()
                {
                    Value = item.Name,
                    Text = item.Name
                });
            }
            ViewBag.courseList = courseList;
            Grade grade = db.Grade.Where(d => d.Id == id).FirstOrDefault();
            return View(grade);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Course,Score")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grade);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grade.Where(d => d.Id == id).FirstOrDefault();
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grade grade = db.Grade.Where(d => d.Id == id).FirstOrDefault();
            var userId = db.User.Where(d => d.UserName == grade.User).Select(s => s.Id).FirstOrDefault();

            db.Grade.Remove(grade);
            db.SaveChanges();
            return RedirectToAction("Manage",new { Id = userId });
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
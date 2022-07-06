using SRAD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Manage(int Id)
        {
            User user = db.User.Find(Id);
            var Model = db.Grade.Where(d => d.User == user.UserName).ToList();
            ViewBag.Id = Id;
            ViewBag.UserName = db.User.Where(d => d.Id == Id).Select(s=>s.UserName).FirstOrDefault();
            return View(Model);
        }
        public ActionResult Create(int Id)
        {
            ViewBag.Id = Id;
            ViewBag.UserName = db.User.Where(d => d.Id == Id).Select(s => s.UserName).FirstOrDefault();
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
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Capstone;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class StudentsController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();
        public List<Student> studentList;
        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpGet]
        public ActionResult Student()
        {
            //string studentName = student.id;
            ////TempData["msg"] = "<script>alert('" + studentId + "');</script>";
            //studentList = db.Students.ToList();
            //var check = studentList.Where(i => i.StudentName.Equals(studentName));
            //if (!check.Any())
            //{
            //    return HttpNotFound();
            //}
            //else
            //{
            //    TempData["msg"] = "<script>alert('" + check + "');</script>";
            //}

            return View();
        }
        //[HttpPost]
        //public ActionResult Student(ReportViewModel student)
        //{
        //    string studentName = student.id;
        //    //TempData["msg"] = "<script>alert('" + studentId + "');</script>";
        //    studentList = db.Students.ToList();
        //    var check = studentList.Where(i => i.StudentName.Equals(studentName));
        //    if (!check.Any())
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Programs");
        //    }

        //    //return View();
        //}
        
        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

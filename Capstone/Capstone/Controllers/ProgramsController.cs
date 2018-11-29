using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class ProgramsController : Controller
    {
        public List<Student> studentList;
        private CapstoneEntities db = new CapstoneEntities();
        public int studentID;
        // GET: Programs
        public ActionResult Index()
        {
          
            return View(db.Programs.ToList());
        }


        [HttpPost]
        public ActionResult Student(ReportViewModel student)
        {
            string studentName = student.id;
            //TempData["msg"] = "<script>alert('" + studentId + "');</script>";
            studentList = db.Students.ToList();
            var check = studentList.Where(i => i.StudentName.Equals(studentName));
            if (!check.Any())
            {
                return HttpNotFound();
            }
            else
            {
         
                studentID= check.Select(id => id.Id).First();               

                Session["test"] = studentID;

                return RedirectToAction("Index", "Programs");
            }


        }

        [HttpPost]
        public ActionResult Fav(ReportViewModel student)
        {
            
            if (Session["test"] != null)
            {
                studentID = Convert.ToInt32(Session["test"]);
                //var x = student.studentID;

                //TempData["msg"] = "<script>alert('" + studentID.ToString() + "');</script>";
                return RedirectToAction("Index", "Favourites");
            }
            else if (Session["test"] == null)
            {
                //TempData["msg"] = "<script>alert('user not found');</script>";
                return RedirectToAction("Index", "Programs");
            }
            else
            {
                return RedirectToAction("Index", "Programs");
            }
                       

        }
        //public ActionResult Report()
        //{
        //    return View(new ReportViewModel());
        //}
        //[HttpPost]
        //public ActionResult Test(ReportViewModel test)
        //{

        //    ViewBag.StudentID = test;
        //    return View();
        //    //return View(db.Programs.ToList());
        //}

        // GET: Programs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pId,ProgranName,Prerequisites,Ouac,MinGrade,School")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Programs.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(program);
        }

        // GET: Programs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pId,ProgranName,Prerequisites,Ouac,MinGrade,School")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(program);
        }

        // GET: Programs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.Programs.Find(id);
            db.Programs.Remove(program);
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

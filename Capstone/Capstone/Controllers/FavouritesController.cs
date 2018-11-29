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
using Capstone.Controllers;


namespace Capstone.Controllers
{
    public class FavouritesController : Controller
    {
        // GET: Favourites
        private CapstoneEntities db = new CapstoneEntities();
        ProgramsController p = new ProgramsController();
        private int studentID;

        FavouriteModel model = new FavouriteModel();

        public ActionResult Index()
        {        

           
             if (Session["test"] != null)
            {
                studentID = Convert.ToInt32(Session["test"]);
                //var name = db.Programs.Where(s => s.Students.Any(c => c.Id == studentID)).Select(x => x.ProgranName);
                var name = db.Programs.Where(s => s.Students.All(c => c.Id == studentID));


                //Program name;
                //using (var context = new CapstoneEntities())
                //{
                //     name = db.Programs
                //        .Where(s => s.Students.Any(c => c.Id == studentID))
                //        .FirstOrDefault<Program>();



                //}


                //foreach (var prog in name)
                //{
                TempData["msg"] = "<script>alert('hello');</script>";
                //}


                return View(name);
            }
            else
            {
                return View();
            }

        }

       
    }
}




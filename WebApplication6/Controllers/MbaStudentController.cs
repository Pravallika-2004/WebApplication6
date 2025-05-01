using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class MbaStudentController : Controller
    {
        // Use your actual DbContext here
        MBAStudentPDEntities1 db = new MBAStudentPDEntities1();

        // GET: MbaStudent
        public ActionResult StudentDetails()
        {
            // Fetch the first (and only) record from the table
            var student = db.mba_student_data.FirstOrDefault();

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        // GET: MbaStudent/Create
        public ActionResult Create()
        {
            return View(); // Shows a blank form to the user
        }

        // POST: MbaStudent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(mba_student_data model)
        {
            if (ModelState.IsValid)
            {
                db.mba_student_data.Add(model);
                db.SaveChanges();
                
                TempData["Message"] = "Student added successfully!";
                return View(new mba_student_data()); // Return Create view with a new, empty model
            }

            return View(model); // Return view again if validation fails
        }

    }
}
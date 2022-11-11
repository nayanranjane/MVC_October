using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class JobApplicationController : Controller
    {
        DBSampleEntities db = new DBSampleEntities();
        // GET: JobApplication
        public ActionResult Index()
        {
            var jobs = db.Jobs.ToList();
            return View(jobs);
        }

        public ActionResult Apply(int id)
        {
            ViewBag.id = id;
            JobApplication jb = new JobApplication() { JobID=id};
            return View(jb);
        }
        [HttpPost]
        public ActionResult Apply(JobApplication jb)
        {
            if (ModelState.IsValid)
            {
                var result = db.JobApplications.Add(jb);
                db.SaveChanges();
                ViewBag.Message= "<script> alert('Applied Successfully')</script>";
                return RedirectToAction("Index", "JobApplication");
            }
            return View();
        }
    }
}
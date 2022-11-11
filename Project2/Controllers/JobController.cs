using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class JobController : Controller
    {
        DBSampleEntities db = new DBSampleEntities();
        // GET: Job
        public ActionResult Index()
        {
            var jobs = db.Jobs.ToList();
            return View(jobs);
        }
    }
}
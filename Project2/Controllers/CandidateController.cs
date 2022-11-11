using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        DBSampleEntities db = new DBSampleEntities();
        public ActionResult Index()
        {
            var result = db.candidates.ToList();
            return View(result);
        }
        public ActionResult AddCandidate()
        {
            candidate candidate = new candidate();
            return View(candidate);
        }
        [HttpPost]
        public ActionResult AddCandidate(candidate candidate)
        {
            try
            {
                candidate.ID = (int)Session["ID"];
                var result = db.candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index", "Usr");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
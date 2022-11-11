using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class CandidateController : Controller
    {
        RM_ProjectEntities db = new RM_ProjectEntities();
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCandidate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCandidate(Candidate candidate)
        {
            candidate.UserID = (int)Session["UserID"];
            try
            {
                var result = db.Candidates.Add(candidate);
                db.SaveChanges();
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}
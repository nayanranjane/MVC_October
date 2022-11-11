using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2.Models;

namespace Project2.Controllers
{
    public class UsrController : Controller
    {
        DBSampleEntities db = new DBSampleEntities();
            // GET: Usr
        public ActionResult Index()
        {
            var result = db.Usrs.ToList();
            return View(result);
        }
        
        public ActionResult AddUsr()
        {
            Usr user = new Usr();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddUsr(Usr user)
        {

            try
            {
                var result = db.Usrs.Add(user);
                db.SaveChanges();
                Session["ID"] = user.ID;
                return RedirectToAction("AddCandidate","Candidate");
            }
            catch (Exception ex)
            {

                return View("error");
            }
        }
    }
}
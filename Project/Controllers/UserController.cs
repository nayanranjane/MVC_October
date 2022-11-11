using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Project.Controllers
{
    public class UserController : Controller
    {
       RM_ProjectEntities db = new RM_ProjectEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid==true)
            {
                var result = db.Users.Add(user);
                db.SaveChanges();
                Session["UserID"] = user.UserID;
                Session["Role"] = user.Role;
                if (user.Role == "Candidate")

                    return RedirectToAction("AddCandidate", "Candidate");
                else
                    return RedirectToAction("AddStaff", "Staff");
            }
            return View();
        }
    }
}
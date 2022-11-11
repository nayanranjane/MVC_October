using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class AdminController : Controller
    {
        DBSampleEntities db = new DBSampleEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usr usr)
        {
            if(db.Usrs.Any(us=>us.UserName==usr.UserName && us.Password == usr.Password))
            {
                Session["UserID"] = usr.ID.ToString();
                Session["Role"] = usr.UserName.ToString();
                ViewBag.Message= "<script>alert('Login Successfull ')</script>";
                return RedirectToAction("Index","Application");
            }
            else
            {
                TempData["Message"] = "<script>alert('Login Failed ')</script>";
                return RedirectToAction("Index","Home");
            }
        }
    }
}
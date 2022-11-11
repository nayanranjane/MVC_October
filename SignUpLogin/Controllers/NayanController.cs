using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignUpLogin.Controllers
{
    public class NayanController : Controller
    {
        // GET: Nayan
        public ActionResult Index()
        {
            if (Session["UserName"].ToString() == ("king").ToString() && Session["UserId"] != null)
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
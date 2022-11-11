using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSystem.Controllers
{
    public class UserController : Controller
    {
        // Registeration Action
        [HttpGet]
        public ActionResult Registeration()
        {
            return View();
        }
    }
}
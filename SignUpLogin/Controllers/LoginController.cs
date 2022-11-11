using SignUpLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SignUpLogin.Controllers
{
    public class LoginController : Controller
    {
        SignUpLoginEntities dbSet = new SignUpLoginEntities();


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var loginUser = dbSet.Users.Where(tUser => tUser.username == user.username && tUser.password == user.password).FirstOrDefault();
            if(loginUser!=null && user.username == "Customer")
            {
                Session["UserId"] = user.Id.ToString();
                Session["UserName"] = user.username.ToString();

            }
            if (loginUser != null)
            {
                Session["UserId"] = user.Id.ToString();
                Session["UserName"] = user.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfully')</script>";
                return RedirectToAction("Index", "User");

            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('UserName or Password is incorrect')</script>";
            }
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid == true)
            {
          
                dbSet.Users.Add(user);
                int isSaved = dbSet.SaveChanges();
                if (isSaved > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registeration not Successfull')</script>";

                }

            }
            return View();
        }

    }

}
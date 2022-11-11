using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class ApplicationController : Controller
    {
        DBSampleEntities db = new DBSampleEntities();
        // GET: Application
        public ActionResult Index()
        {
            if (Session.SessionID!=null)
            {
                var result = (from user in db.Usrs.ToList()
                              join candi in db.candidates.ToList()
                              on user.ID equals candi.ID
                              select new ResponseIndex()
                              {
                                  ID = candi.ID,
                                  UserName = user.UserName,
                                  Password = user.Password,
                                  Location = candi.location,
                                  MobileNo = candi.MobileNo
                              }).ToList();

                return View(result);
            }
            else
            {
                ViewBag.ErrorMessage = "<script> alert('You are not authorized for this action'); </script>";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
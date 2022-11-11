using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question

        RM_ProjectEntities db = new RM_ProjectEntities();
        public ActionResult Index()
        {
            var questions = db.AptitudeQuestions.ToList();
            if (questions == null)
                ViewData["noQuestions"] = true;
            return View(questions);
        }
    }
}
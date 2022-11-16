using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.Entities;
using Coditas.Ecom.Repositories;
using MVC_App.CustomSessionExtensions;

namespace MVC_App.Controllers
{
    public class CategoryController : Controller
    {
        IDbRepository<Category, int> dbAccess;

        public CategoryController(IDbRepository<Category, int> dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var records = await dbAccess.GetAsync();
                return View(records);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        public async Task<IActionResult> Create()
        {
            try
            {
                
                Category category = new Category();
                //if (TempData != null && TempData.Count()!=0)
                //{
                //    category.CategoryName =(string) TempData["CateogoryName"];
                //    category.CategoryId = (int)TempData["CategoryId"];
                //    category.BasePrice = (int)TempData["BasePrice"];
                //}
                if (HttpContext.Session.GetObject<Category>("Session") != null)
                {
                    category = HttpContext.Session.GetObject<Category>("Session");
                    ViewBag.ErrorMessage = HttpContext.Session.GetString("ErrorMessage");
                    ViewData["ErrorMessage"] = HttpContext.Session.GetString("ErrorMessage");
                    HttpContext.Session.Clear();
                }

                return View(category);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            if (ModelState.IsValid)
            {
                var response = await dbAccess.CreateAsync(category);
                if (category.BasePrice < 0)
                {
                    //TempData["CategoryId"] = category.CategoryId;
                    //TempData["CategoryName"] = category.CategoryName;
                    //TempData["BasePrice"] = category.BasePrice;

                    HttpContext.Session.SetObject<Category>("Session", category);
                    HttpContext.Session.SetString("ErrorMessage", "Base price cannot be -ve");
                    //TempData.Keep();
                    throw new Exception("Base Price Cannot be -ve");
                    // Return to Index Action Method in Same


                }
                // Controller
              
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(category);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var record = await dbAccess.GetAsync(id);
                return View(record);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Category category)
        {
            try
            {
                var result = await dbAccess.UpdateAsync(id, category);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbAccess.DeleteAsync(id);
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await dbAccess.GetAsync(id);
            return View(result);
        }
        public async Task<IActionResult> Product(int id)
        {
            var product = await dbAccess.GetAsync(id);
            return View(product);



        }
    }

}

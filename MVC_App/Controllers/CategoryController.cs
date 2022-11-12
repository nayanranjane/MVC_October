using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.Entities;
using Coditas.Ecom.Repositories;

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
            try
            {
                var response = await dbAccess.CreateAsync(category);
                return RedirectToAction("Index", "Category");   
            }
            catch (Exception ex)
            {

                return View("Error");
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

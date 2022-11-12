using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.DataAccess;
using Coditas.Ecomm.Entities;
using Coditas.Ecom.Repositories;

namespace MVC_App.Controllers
{
    public class CategoryProductController : Controller
    {
        IDbRepository<Category, int> dbCategory;
        IDbRepository<Product, int> dbProduct;

        public CategoryProductController(IDbRepository<Category, int> dbCategory, IDbRepository<Product, int> dbProduct)
        {
            this.dbCategory = dbCategory;
            this.dbProduct = dbProduct;
        }

        public async Task<IActionResult> Index(int? id)
        {
            List<Category> categories = null;
            List<Product> products = null;
            Tuple<List<Category>, List<Product>> tuple = null;

            categories = (await dbCategory.GetAsync()).ToList();
            if(id == null)
            {
                products = (await dbProduct.GetAsync()).ToList();
            }
            else
            {
                products = (await dbProduct.GetAsync()).ToList().Where(prd => prd.CategoryId == id).ToList();

            }
            tuple = new Tuple<List<Category>, List<Product>>(categories, products);

            return View(tuple);
        }
        public IActionResult ShowDetails(int? id)
        {
            return RedirectToAction("Index", new { id = id });

        }
    }
}

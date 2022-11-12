using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.DataAccess;
using Coditas.Ecom.Repositories;
using Coditas.Ecomm.Entities;
using Microsoft.EntityFrameworkCore;

namespace MVC_App.Controllers
{
    public class ProductController : Controller
    {

        IDbRepository<Product, int> dbProduct;
        public ProductController(IDbRepository<Product, int> dbProduct)
        {
            this.dbProduct = dbProduct;
        }

        public async Task<IActionResult> Index()
        {
            var productList = (await dbProduct.GetAsync()).ToList();
            return View(productList);
        }
        public async Task<IActionResult> Create()
        {
             Product product = new Product();
             return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await dbProduct.CreateAsync(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        { 
            var result = await dbProduct.GetAsync(id);
            return View(result);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id,Product product)
        {
            var result = await dbProduct.UpdateAsync(id, product);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await dbProduct.GetAsync(id);
            return View(result);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbProduct.DeleteAsync(id);
            return RedirectToAction("Index", "Product");

        }



    }
}

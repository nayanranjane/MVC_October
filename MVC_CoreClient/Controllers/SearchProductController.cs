using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC_CoreClient.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_CoreClient.Models;
using System.Diagnostics;
using ClientNs;
using System.Text.Json;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_CoreClient.Controllers
{
    public class SearchProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null;
        string baseUrl = string.Empty;
        GeneratedCode proxy;
        public SearchProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
            baseUrl = "https://localhost:7124";
            client = new HttpClient();
            proxy = new GeneratedCode(baseUrl, client);
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Category()
        {


            var result = (await proxy.GetcategotiesAsync()).ToList();
            ViewData["Categories"] = result;
            List<Category> categoryItem = new List<Category>();
            foreach (var item in result)
            {
                categoryItem.Add(new Category { CategoryId=item.CategoryId,CategoryName=item.CategoryName,BasePrice=item.BasePrice});
            }
            ViewBag.Categories = categoryItem;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Category(CategorySearchModel categorySearchModel)
        {
            TempData["Id"] = categorySearchModel.CategoryId;
            return RedirectToAction("ShowProduct", "Search");
        }
        public async Task<IActionResult> ShowProduct()
        {
            int id = (int)TempData["Id"];
            var products = (await proxy.GetproductlistAsync()).ToList().Where(prd => prd.CategoryId == id).ToList();
            return View(products);
        }
        public IActionResult ShowDetails(int? id)
        {
            return RedirectToAction("CategoryProduct", new { id = id });

        }
    }
}

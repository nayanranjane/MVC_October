using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SearchSpace;
using MVC_SearchProject.Models;

namespace MVC_SearchProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null;
        string baseUrl = string.Empty;
        SearchClass proxy = null;
        public ProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
            baseUrl = "https://localhost:7146";
            client = new HttpClient();
            proxy = new SearchClass(baseUrl, client);
        }
        public async Task<IActionResult> Index(string? str)
        {
            SearchString s = new SearchString();
            List<Product> products = new List<Product>();
            ViewBag.Search = str;
            if (str != null)
            {
                 products =(await proxy.SearchproductAsync(str)).ToList();
                 ViewBag.Product = products;

            }
            else
            {
                 products = (await proxy.GetproductsAsync()).ToList();
                ViewBag.Product = products; 
            }
            return View(s);
          
        }
        [HttpPost]
        public IActionResult Index(SearchString search)
        {
            return RedirectToAction("Index", new { str = search.statement });

        }
        [HttpPost]
        public IActionResult ShowProcuduct(string str)
        {
            return RedirectToAction("Index", new { str = str });
        }
    }
}

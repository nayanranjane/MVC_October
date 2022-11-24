using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SearchOperation;


namespace MVC_SearchClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null;
        string baseUrl = string.Empty;
        SearchClass proxy= null;
        public ProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
            baseUrl = "https://localhost:7083";
            client = new HttpClient();
            proxy = new SearchClass(baseUrl, client);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Index(string? search)
        {
            
            var products =await proxy.SearchproductAsync(search);

            return View(products);
        }
        public IActionResult ShowDetails(int? id)
        {
            return RedirectToAction("Index", new { id = id });

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC_CoreClient.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_CoreClient.Models;
using System.Diagnostics;
using ClientNs;
using System.Text.Json;

namespace MVC_CoreClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null;
        string baseUrl = string.Empty;
        CategoryNew proxy;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            baseUrl = "https://localhost:7124";
            client = new HttpClient();
            proxy = new CategoryNew(baseUrl, client);
        }

        public async Task<IActionResult> Index()
        {
            var result = await proxy.GetcategotiesAsync();
            //var Cat = new Category()
            //{
            //    CategoryId = 2016,
            //    CategoryName = "MyCat",
            //    BasePrice = 30
            //};
            //var result = await proxy.CreatecategoryAsync(Cat);

            ViewBag.Categories = JsonSerializer.Serialize(result);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
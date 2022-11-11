using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.Models;
using System.Linq;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // This is the attribute respresent 
    public class AddController : Controller
    {
        IDbAccessService<Category, int> catService;
        IDbAccessService<Product, int> productService;

        public AddController(IDbAccessService<Category, int> catService, IDbAccessService<Product, int> productService)
        {

            this.catService = catService;
            this.productService = productService;
        }

      
    }
}

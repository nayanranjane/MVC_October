using Microsoft.AspNetCore.Mvc;
using NorthWindDatabase.Models;
using NorthWindDatabase.Services;

namespace NorthWindDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IDbAccessService<Product,int> productsDataAccessService;
        public ProductController(IDbAccessService<Product, int> productsDataAccessService)
        {
            this.productsDataAccessService = productsDataAccessService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await productsDataAccessService.GetAsync();
            return Ok(result);
        }
    }
}

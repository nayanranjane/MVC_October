using webApi.Models;
using webApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using webApi.Services;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CategoryOASController : ControllerBase
    {

        IDbAccessService<Category, int> catDbAccess;
        IDbAccessService<Product, int> prodDbAccess;
        public CategoryOASController(IDbAccessService<Category, int> catDbAccess, IDbAccessService<Product, int> prodDbAccess)
        {
            this.catDbAccess = catDbAccess;
            this.prodDbAccess = prodDbAccess;
        }
        /// <summary>
        /// MOdify the HTTP Action Method to
        /// return Managed Object Instead of HttpResponseMessage (IActionResult)
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getcategoties")]
        public async Task<IEnumerable<Category>> Get()
        {
            var result = await catDbAccess.GetAsync();
            return result;
        }

        [HttpPost("/createcategory")]
        public async Task<Category> Post(Category category)
        {
            var result = await catDbAccess.CreateAsync(category);
            return result;
        }

        [HttpGet("/getproductlist")]

        public async Task<IEnumerable<Product>> GetProduct()
        {
            var result = await prodDbAccess.GetAsync();
            return result;
        }

        [HttpGet("/getproductwithcategory")]

        public async Task<IEnumerable<Product>> GetProductWithCategory(int id)
        {
            var result =( await prodDbAccess.GetAsync()).ToList().Where(prd=>prd.CategoryId==id).ToList();
            return (result);
        }
    }
}
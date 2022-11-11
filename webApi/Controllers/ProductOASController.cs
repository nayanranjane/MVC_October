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
    public class ProductOASController : ControllerBase
    {
        IDbAccessService<Category, int> prodDbAccess;

        public ProductOASController(IDbAccessService<Category, int> prodDbAccess)
        {
            this.prodDbAccess = prodDbAccess;
        }
        /// <summary>
        /// MOdify the HTTP Action Method to
        /// return Managed Object Instead of HttpResponseMessage (IActionResult)
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getproducts")]
        public async Task<IEnumerable<Category>> Get()
        {
            var result = await prodDbAccess.GetAsync();
            return result;
        }

        [HttpPost("/createproduct")]
        public async Task<Category> Post(Category category)
        {
            var result = await prodDbAccess.CreateAsync(category);
            return result;
        }
    }
}
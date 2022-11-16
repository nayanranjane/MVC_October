using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using NorthWindAPI.Models;
using System.Net;

namespace NorthWindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCacheController : Controller
    {
        IMemoryCache memoryCache;
        NorthwindContext dbContext;

        public CategoryCacheController(IMemoryCache memoryCache, NorthwindContext dbContext)
        {
            this.memoryCache = memoryCache;
            this.dbContext = dbContext;
        }

        [HttpGet("/getcats")]
        public async Task<ResponseObject> GetAsync()
        {
            ResponseObject response = new ResponseObject();
            List < CustomersEmployeesShipper > customeremployeeList= null;
            try
            {
                var isDataAvailabe = memoryCache.TryGetValue(cacheKey, out CustomersEmployeesShipper);
                if (!isDataAvailabe)
                {
                    customeremployeeList = await dbContext.CustomersEmployeesShippers.ToListAsync();
                    response.Ca
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}

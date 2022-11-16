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
    public class CategoryProductRestController : Controller
    {

        IDbAccessService<Product, int> productService;
        IDbAccessService<Category, int> categoryService;

        public CategoryProductRestController(IDbAccessService<Product, int> productService, IDbAccessService<Category, int> categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet("/getmatchingproduct")]

        public async Task<IEnumerable<Product>> getMatchProduct(string categoryName,int maxRecord)
        {
            var category = new Category();
            category = (await categoryService.GetAsync()).ToList().Where(ct => ct.CategoryName == categoryName).FirstOrDefault();

            var products = new List<Product>();

            if (category.CategoryId != null)
            {
                products = (await productService.GetAsync()).ToList().Where(prd => prd.CategoryId == category.CategoryId).Take(maxRecord).ToList();
                

            }
            if(maxRecord == 0)
            {
                 products = (await productService.GetAsync()).ToList().Where(prd => prd.CategoryId == category.CategoryId).ToList();

            }
            if(maxRecord > 0)
            {
                products = (await productService.GetAsync()).ToList().Where(prd => prd.CategoryId == category.CategoryId).Take(maxRecord).ToList();

            }
            return products;
        }

        [HttpGet("/getmatchingproductwithpage")]
        public async Task<Tuple<IEnumerable<Product>,int>> getMatchProductWithPage(string categoryName)
        {
            var category = new Category();
            category = (await categoryService.GetAsync()).ToList().Where(ct => ct.CategoryName == categoryName).FirstOrDefault();

            var totalProducts = (await productService.GetAsync()).ToList().Where(pd => pd.CategoryId == category.CategoryId).ToList();


            int Count = totalProducts.Count();

            int currentPage = Pagination.pageNo;
            int size = Pagination.pageSize;

            var result = totalProducts.Skip((currentPage - 1) * size).Take(size).ToList();


            Tuple<IEnumerable<Product>, int> tuple = null;
            tuple = new Tuple<IEnumerable<Product>, int>(result, currentPage);
            Pagination.pageNo++;
            return tuple;
        }
    }
}

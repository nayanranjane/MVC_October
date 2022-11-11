using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.Models;
using System.Linq;
namespace webApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        IDbAccessService<Category, int> catService;
        IDbAccessService<Product,int > productService;

        public SearchController(IDbAccessService<Category, int> catService, IDbAccessService<Product, int> productService)
        {
            this.catService = catService;
            this.productService = productService;
        }


        [HttpGet]

        [ActionName("and")]
        public async Task<IActionResult> Search(string ProdName , string CatName)
        {
            var catResult = await catService.GetAsync();
            var productResult = await productService.GetAsync();

       
            var result = (from cat in catResult
                          join prod in productResult
                          on cat.CategoryId equals prod.CategoryId
                          where cat.CategoryName==CatName && prod.ProductName==ProdName
                          select new
                          {
                              ProductName = prod.ProductName,
                              CategoryName = cat.CategoryName,
                              ProductId = prod.ProductUniqueId,
         
                              ProductDescription = prod.Descrition,
                              ProductPrice = prod.Price

                          });
            if (ProdName == "null")
            {
                var result3 = catResult.Where(name => name.CategoryName == CatName);
                return Ok(result3);
            }
            else if(CatName == "null")
            {
                var result4 = productResult.Where(name => name.ProductName == ProdName);
                return Ok(result4);
            }
            else if (result.Count()==0)
            {
                var result2 = (from cat in catResult
                              join prod in productResult
                              on cat.CategoryId equals prod.CategoryId
                              where cat.CategoryName == CatName || prod.ProductName == ProdName
                              select new
                              {
                                  ProductName = prod.ProductName,
                                  CategoryName = cat.CategoryName,
                                  ProductId = prod.ProductUniqueId,
  
                                  ProductDescription = prod.Descrition,
                                  ProductPrice = prod.Price

                              });
                return Ok(catResult);
            }
            return Ok(result);
        }
      
     

    }
}

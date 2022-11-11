using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        IDbAccessService<Product, int> productService;
        IDbAccessService<Category, int> categoryService;

        public ProductController(IDbAccessService<Product,int> productService,IDbAccessService<Category,int> categoryService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await productService.GetAsync();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await productService.DeleteAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                //var isCategoryExist = (await categoryService.GetAsync())
                //    .Where(name => name.CategoryName == product.CategoryName)
                //    .FirstOrDefault();
                //if(isCategoryExist!= null)
                //{
                //    return Conflict($"There is alreay a Category with Name {product.CategoryName} exist.");
                //}

               
                
                var result = await productService.CreateAsync(product);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, Product product)
        {
            var result = await productService.UpdateAsync(product, id);
            return Ok(result);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.Models;


namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // This is the attribute respresent 
    public class CategoryController : ControllerBase 
    {
        IDbAccessService<Category, int> catService;

        public CategoryController(IDbAccessService<Category, int> catService)
        {
            this.catService = catService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await catService.GetAsync();
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> Update(Category category , int id)
        {
            var result = await catService.UpdateAsync(category,id);
            return Ok(result);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await catService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category cat)
        {
            var result = await catService.CreateAsync(cat);
            return Ok(result);
        }
     
    }

}

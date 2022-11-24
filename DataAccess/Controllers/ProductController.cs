using DataAccess.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IDbAccessService<Product, int> prodDbAccess;

        public ProductController(IDbAccessService<Product, int> prodDbAccess)
        {
            this.prodDbAccess = prodDbAccess;
        }

        [HttpGet("/getproducts")]
        public async Task<IEnumerable<Product>> Get()
        {
            var result = await prodDbAccess.GetAsync();
            return result;
        }

        [HttpPost("/createproduct")]
        public async Task<Product> Post(Product category)
        {
            var result = await prodDbAccess.CreateAsync(category);
            return result;
        }

        [HttpPost("/searchproduct")]
        public async Task<IEnumerable<Product>> Search(string searchString)
        {
            var m = searchString.Split(' ');
            var j = m.ToList();
            //string[] words = new string[5];
            //  words= searchString.Split(',');
            //List<string> wordss = new List<string>();
            //for (int i = 0; i < words.Count(); i++)
            //    wordss.Add(words[i]);
            //while (5 - wordss.Count > 0)
            //{
            //    wordss.Add(null);
            //}

            List<List<Product>> prdList = new List<List<Product>>();

            var products = await prodDbAccess.GetAsync();

            //var result = (from product in products
            //             where ( product.ProductName.ToString().Contains(searchString))
            //             || (product.Seller.ToString().Contains(searchString))
            //             ||(product.Description.ToString().Contains(searchString))
            //             || (product.Price.ToString().Contains(searchString))
            //             ||(product.Manufacturer.ToString().Contains(searchString))
            //             select product);

            foreach(var item in j)
            {
                 var temp = (from product in products
                                where (product.ProductName.ToString().ToLower().Contains(item.ToLower()))
                                || (product.Seller.ToString().ToLower().Contains(item.ToLower()))
                                || (product.Description.ToString().ToLower().Contains(item.ToLower()))
                                || (product.Price.ToString().Contains(item.ToLower()))
                                || (product.Manufacturer.ToString().ToLower().Contains(item.ToLower()))
                                select product).ToList();

                prdList.Add(temp);
            }

            var result =new List<Product>();
            switch (prdList.Count())
            {
                case 0:
                    result = null;
                    break;
                case 1:
                    result = prdList[0];
                    break;
                case 2:
                    result = (prdList[0].Intersect(prdList[1])).ToList();
                    break;
                case 3:
                    result = (prdList[0].Intersect(prdList[1]).Intersect(prdList[2])).ToList();
                    break;
                case 4:
                    result = (prdList[0].Intersect(prdList[1]).Intersect(prdList[2]).Intersect(prdList[3])).ToList();
                    break;
                case 5:
                    result = (prdList[0].Intersect(prdList[1]).Intersect(prdList[2]).Intersect(prdList[3]).Intersect(prdList[4])).ToList();
                    break;
            }

            return result;




        }
    }
}

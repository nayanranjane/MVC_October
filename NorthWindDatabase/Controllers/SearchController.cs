using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindDatabase.Services;
using NorthWindDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NorthWindDatabase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        IDbAccessService<Product, int> productService;
        IDbAccessService<Order, int> orderService;
        IDbAccessService<OrderDetail, int> orderDetailsService;
        IDbAccessService<Customer, int> customerService;


        public SearchController(IDbAccessService<Product, int> productService, IDbAccessService<Order, int> orderService, IDbAccessService<OrderDetail, int> orderDetailsService, IDbAccessService<Customer, int> customerService)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.orderDetailsService = orderDetailsService;
            this.customerService = customerService;
        }

        [HttpGet]
        [ActionName("Find")]
        public async Task<IActionResult> Get(string Name)
        {
            try
            {
                var result = from ordet in await orderDetailsService.GetAsync()
                             join or in await orderService.GetAsync()
                             on ordet.OrderId equals or.OrderId

                             join prod in await productService.GetAsync()
                             on ordet.ProductId equals prod.ProductId

                             join cust in await customerService.GetAsync()
                             on or.CustomerId equals cust.CustomerId

                             where prod.ProductName == Name

                             select new Customer()
                             {
                                 CustomerId = cust.CustomerId,
                                 ContactName = cust.ContactName,
                                 CompanyName = cust.CompanyName,
                                 ContactTitle = cust.ContactTitle,
                                 Address = cust.Address,
                                 City = cust.City,
                                 Region = cust.Region,
                                 PostalCode = cust.PostalCode,
                                 Country = cust.Country,
                                 Phone = cust.Phone,
                                 Fax = cust.Fax
                             };
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
                return BadRequest("Error Occured");
            }

           
            
        }
        [HttpGet]
        [ActionName("TotalOrder")]
        public async Task<IActionResult> TotalOrder()
        {
            var result = from ordet in await orderDetailsService.GetAsync()
                         join or in await orderService.GetAsync()
                         on ordet.OrderId equals or.OrderId

                         join prod in await productService.GetAsync()
                         on ordet.ProductId equals prod.ProductId

                         join cust in await customerService.GetAsync()
                         on or.CustomerId equals cust.CustomerId

                         group or by or.CustomerId into orC
                         select new
                         {
                             CustomerID = orC.Key,
                             TotalOrders =orC.Count()
                         };
            return Ok(result);

        }

        [HttpGet]
        [ActionName("CityMax")]
        public async Task<IActionResult> CityMax()
        {
            var result = (from ordet in await orderDetailsService.GetAsync()
                          join or in await orderService.GetAsync()
                          on ordet.OrderId equals or.OrderId

                          join prod in await productService.GetAsync()
                          on ordet.ProductId equals prod.ProductId

                          join cust in await customerService.GetAsync()
                          on or.CustomerId equals cust.CustomerId

                          group cust by or.ShipCity into orCity
                          select new
                          {
                              CityName = orCity.Key,
                              CountOfOrder = orCity.Count()
                          }).ToList().OrderByDescending(city => city.CountOfOrder).Take(1);

            return Ok(result);

        }
        [HttpGet]
        [ActionName("CityAscendingOrder")]
        public async Task<IActionResult> CityOrder()
        {
            var result = (from ordet in await orderDetailsService.GetAsync()
                          join or in await orderService.GetAsync()
                          on ordet.OrderId equals or.OrderId

                          join prod in await productService.GetAsync()
                          on ordet.ProductId equals prod.ProductId

                          join cust in await customerService.GetAsync()
                          on or.CustomerId equals cust.CustomerId

                          group cust by or.ShipCity into orCity
                          select new
                          {
                              CityName = orCity.Key,
                              CountOfOrder = orCity.Count()
                          }).ToList().OrderBy(city=>city.CountOfOrder);

            return Ok(result);

        }
    }
}

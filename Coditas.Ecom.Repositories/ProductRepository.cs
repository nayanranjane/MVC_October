using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coditas.Ecomm.DataAccess;
using Coditas.Ecomm.DataAccess.Models;
using Coditas.Ecomm.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coditas.Ecom.Repositories
{
    public class ProductRepository : IDbRepository<Product, int>
    {
        EShoppingCodiContext context;
        public ProductRepository(EShoppingCodiContext context)
        {
            this.context = context;
        }
        async Task<Product> IDbRepository<Product, int>.CreateAsync(Product entity)
        {
            try
            {
                var result = await context.Products.AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Product> IDbRepository<Product, int>.DeleteAsync(int id)
        {
            var recordToDelete = await context.Products.FindAsync(id);
            if (recordToDelete == null) throw new Exception("Record for Delete is not found");

            context.Products.Remove(recordToDelete);
            int result = await context.SaveChangesAsync();
            if (result > 0) return recordToDelete;
            else
            {
                return null;
            }
        }

        async Task<IEnumerable<Product>> IDbRepository<Product, int>.GetAsync()
        {
            return await context.Products.ToListAsync();
        }

        async Task<Product> IDbRepository<Product, int>.GetAsync(int id)
        {
            var record = await context.Products.FindAsync(id);
            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }

        async Task<Product> IDbRepository<Product, int>.UpdateAsync(int id, Product entity)
        {
            try
            {
                var recordToUpate = await context.Products.FindAsync(id);
                if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");
               //
                recordToUpate.ProductName = entity.ProductName;
                recordToUpate.Descrition = entity.Descrition;
                recordToUpate.Price = entity.Price;
                recordToUpate.CategoryId = entity.CategoryId;
              //  recordToUpate.Manufacturer = entity.Manufacturer;
                await context.SaveChangesAsync();
                return recordToUpate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

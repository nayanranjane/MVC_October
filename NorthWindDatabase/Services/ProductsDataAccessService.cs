using Microsoft.EntityFrameworkCore;
using NorthWindDatabase.Models;

namespace NorthWindDatabase.Services
{
    public class ProductsDataAccessService : IDbAccessService<Product,int>
    {
        NorthwindContext context;
        // 
        // Injection. 
        public ProductsDataAccessService(NorthwindContext context)
        {
            this.context = context;
        }
        async Task<Product> IDbAccessService<Product, int>.CreateAsync(Product entity)
        {
            try
            {
                var res = await context.Products.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<bool> IDbAccessService<Product, int>.DeleteAsync(int id)
        {
            try
            {
                var rec = await context.Products.FindAsync(id);
                if (rec == null)
                {

                    throw new Exception("Record to delete is not found ");
                    return false;
                }
                else
                {
                    context.Products.Remove(rec);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<IEnumerable<Product>> IDbAccessService<Product, int>.GetAsync()
        {
            try
            {
                var res = await context.Products.ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Product> IDbAccessService<Product, int>.GetAsync(int id)
        {
            try
            {
                var result = await context.Products.FindAsync(id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("The record not found !!!!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using NorthWindDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace NorthWindDatabase.Services
{
    public class OrderDataAccessService:IDbAccessService<Order,int>
    {
        NorthwindContext context;
        // 
        // Injection. 
        public OrderDataAccessService(NorthwindContext context)
        {
            this.context = context;
        }
        async Task<Order> IDbAccessService<Order, int>.CreateAsync(Order entity)
        {
            try
            {
                var res = await context.Orders.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<bool> IDbAccessService<Order, int>.DeleteAsync(int id)
        {
            try
            {
                var rec = await context.Orders.FindAsync(id);
                if (rec == null)
                {

                    throw new Exception("Record to delete is not found ");
                    return false;
                }
                else
                {
                    context.Orders.Remove(rec);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<IEnumerable<Order>> IDbAccessService<Order, int>.GetAsync()
        {
            try
            {
                var res = await context.Orders.ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Order> IDbAccessService<Order, int>.GetAsync(int id)
        {
            try
            {
                var result = await context.Orders.FindAsync(id);
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

        //async Task<Category> IDbAccessService<Category, int>.UpdateAsync(Category entity, int id)
        //{
        //    try
        //    {
        //        var res = await context.Categories.FindAsync(id);
        //        if (res != null)
        //        {
        //            res.CategoryName = entity.CategoryName;
        //            res.CategoryId = entity.CategoryId;
        //            res.BasePrice = entity.BasePrice;
        //            await context.SaveChangesAsync();
        //            return res;
        //        }
        //        else
        //        {
        //            throw new Exception("Record not found to update !!!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}

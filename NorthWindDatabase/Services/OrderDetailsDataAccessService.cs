using NorthWindDatabase.Models;
using Microsoft.EntityFrameworkCore;


namespace NorthWindDatabase.Services
{
    public class OrderDetailsDataAccessService:IDbAccessService<OrderDetail,int>
    {
        NorthwindContext context;
        // 
        // Injection. 
        public OrderDetailsDataAccessService(NorthwindContext context)
        {
            this.context = context;
        }
        async Task<OrderDetail> IDbAccessService<OrderDetail, int>.CreateAsync(OrderDetail entity)
        {
            try
            {
                var res = await context.OrderDetails.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<bool> IDbAccessService<OrderDetail, int>.DeleteAsync(int id)
        {
            try
            {
                var rec = await context.OrderDetails.FindAsync(id);
                if (rec == null)
                {

                    throw new Exception("Record to delete is not found ");
                    return false;
                }
                else
                {
                    context.OrderDetails.Remove(rec);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<IEnumerable<OrderDetail>> IDbAccessService<OrderDetail, int>.GetAsync()
        {
            try
            {
                var res = await context.OrderDetails.ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<OrderDetail> IDbAccessService<OrderDetail, int>.GetAsync(int id)
        {
            try
            {
                var result = await context.OrderDetails.FindAsync(id);
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

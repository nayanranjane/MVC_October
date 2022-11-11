using NorthWindDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace NorthWindDatabase.Services
{
    public class CustomerDataAccessService:IDbAccessService<Customer,int>
    {
        NorthwindContext context;
        // 
        // Injection. 
        public CustomerDataAccessService(NorthwindContext context)
        {
            this.context = context;
        }
        async Task<Customer> IDbAccessService<Customer, int>.CreateAsync(Customer entity)
        {
            try
            {
                var res = await context.Customers.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<bool> IDbAccessService<Customer, int>.DeleteAsync(int id)
        {
            try
            {
                var rec = await context.Customers.FindAsync(id);
                if (rec == null)
                {

                    throw new Exception("Record to delete is not found ");
                    return false;
                }
                else
                {
                    context.Customers.Remove(rec);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<IEnumerable<Customer>> IDbAccessService<Customer, int>.GetAsync()
        {
            try
            {
                var res = await context.Customers.ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Customer> IDbAccessService<Customer, int>.GetAsync(int id)
        {
            try
            {
                var result = await context.Customers.FindAsync(id);
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

        //async Task<Customer> IDbAccessService<Customer, int>.UpdateAsync(Customer entity, int id)
        //{
        //    try
        //    {
        //        var res = await context.Customers.FindAsync(id);
        //        if (res != null)
        //        {
        //            res.CompanyName = entity.CompanyName;
        //            res.ContactName = entity.ContactName;
        //            res.ContactTitle = entity.ContactTitle;
        //            res.Region = entity.Region;
        //            res.Address = entity.Address;
        //            res.City = entity.City;
        //            res.Country = entity.Country; 
        //            res.Fax = entity.Fax;
        //            res.PostalCode = entity.PostalCode;
        //            res.Phone = entity.Phone;
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

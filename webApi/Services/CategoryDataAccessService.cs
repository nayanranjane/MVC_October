using webApi.Models;
using webApi;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webApi.Services
{
    public class CategoryDataAccessService : IDbAccessService<Category, int>
    {
        DBSampleContext context;
        // 
        // Injection. 
        public CategoryDataAccessService(DBSampleContext context)
        {
            this.context = context;
        }
        async Task<Category> IDbAccessService<Category, int>.CreateAsync(Category entity)
        {
            try
            {
                var res = await context.Categories.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<bool> IDbAccessService<Category, int>.DeleteAsync(int id)
        {
            try
            {
                var rec = await context.Categories.FindAsync(id);
                if(rec == null)
                {
              
                    throw new Exception("Record to delete is not found ");
                    return false;
                }
                else
                {
                    context.Categories.Remove(rec);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        async Task<IEnumerable<Category>> IDbAccessService<Category, int>.GetAsync()
        {
            try
            {
                var res = await context.Categories.ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Category> IDbAccessService<Category, int>.GetAsync(int id)
        {
            try
            {
                var result = await context.Categories.FindAsync(id);
                if(result != null)
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

        async Task<Category> IDbAccessService<Category, int>.UpdateAsync(Category entity, int id)
        {
            try
            {
                var res = await context.Categories.FindAsync(id);
                if(res != null)
                {
                    res.CategoryName = entity.CategoryName;
                    res.CategoryId = entity.CategoryId;
                    res.BasePrice = entity.BasePrice;
                    await context.SaveChangesAsync();
                    return res;
                }
                else
                {
                    throw new Exception("Record not found to update !!!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

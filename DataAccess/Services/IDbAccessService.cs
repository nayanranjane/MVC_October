namespace DataAccess.Services
{
    public interface IDbAccessService<TEntity , in Tpk> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(Tpk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity,Tpk id);
        Task<bool> DeleteAsync(Tpk id);

    }
}

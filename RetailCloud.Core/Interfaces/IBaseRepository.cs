using System.Collections.Generic;
using System.Threading.Tasks;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecifications<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification);
        Task<int> CountAsync(ISpecifications<T> specifications);
        Task<T> GetByIdAsync(long id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task SaveChangesAsync();
        int SaveChanges();
    }
}
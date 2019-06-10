using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DAL.Repositories
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<List<T>> AddAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> UpdateAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(List<T> entities);
    }
}

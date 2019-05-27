using Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DAL.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _db;

        public AsyncRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<T> GetAsync(Guid id)
        {
            return await _db.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = _db.Set<T>().AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            await _db.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await UpdateAsync(entity);            

            return entities;
        }

        public async Task DeleteAsync(T entity)
        {
            Attach(entity);
            _db.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await DeleteAsync(entity);
        }

        private void Attach(T entity)
        {
            var local = _db.Set<T>().Local.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (local != null)
                _db.Entry(local).State = EntityState.Detached;

            if (_db.Entry(entity).State == EntityState.Detached)
                _db.Set<T>().Attach(entity);
        }
    }
}

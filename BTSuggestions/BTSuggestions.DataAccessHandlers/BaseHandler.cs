using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.DataAccessHandlers;
using Microsoft.EntityFrameworkCore;

namespace BTSuggestions.DataAccessHandlers
{
    public abstract class BaseHandler<T> : IBaseHandler<T> where T : class, IBaseEntity
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _context;

        public BaseHandler(BTSuggestionContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IQueryable<T>> AsQueryable()
        {
            var result = _dbSet.AsQueryable();
            return await Task.FromResult(result);
        }

        public async Task<bool> Contains(T entity)
        {
            return await _dbSet.ContainsAsync(entity);
        }

        public async Task<long> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<long> Count(Expression<Func<T, bool>> where)
        {
            var result = await _dbSet.CountAsync(where);
            return result;
        }

        public Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> First(Expression<Func<T, bool>> where)
        {
            return await _dbSet.FirstAsync(where);
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FirstAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> GetByIds(IEnumerable<int> ids)
        {
            return await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task InsertMany(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }
    }
}

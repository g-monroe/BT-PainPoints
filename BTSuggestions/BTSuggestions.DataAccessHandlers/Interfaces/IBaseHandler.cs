using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface IBaseHandler<T> where T : IBaseEntity
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        T GetById(int id);
        IEnumerable<T> GetByIds(IEnumerable<int> ids);
        T First(Expression<Func<T, bool>> where);
        bool Contains(T entity);
        long Count();
        long Count(Expression<Func<T, bool>> where);

        T Insert(T entity);
        void InsertMany(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);

        void SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeShark.Core.Contracts.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task AddAsync(T entity);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> where);

        Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        void Update(T entity);

        void Remove(T entity);

        void SetInactive(T entity);
    }
}

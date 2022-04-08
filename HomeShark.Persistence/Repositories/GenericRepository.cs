using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HomeShark.Core.Contracts;
using HomeShark.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HomeShark.Persistence.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly HomeSharkContext Context;

        public GenericRepository(HomeSharkContext context) => Context = context;

        public async Task AddAsync(T entity) => await Context.Set<T>().AddAsync(entity);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> where) => await GetAsync(where) != null;

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            var query = Context.Set<T>().AsQueryable();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            var query = Context.Set<T>().AsQueryable();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            var query = Context.Set<T>().AsQueryable();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            return await query.Where(where).ToListAsync();
        }

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public void Remove(T entity) => Context.Set<T>().Remove(entity);

        public void SetInactive(T entity) => entity.EntityActive = false;
    }
}

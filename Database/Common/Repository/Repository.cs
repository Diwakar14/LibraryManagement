using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryManagement.Database.Common.Repository
{
    public class Repository<TModel, TDbContext> : IRepository<TModel, TDbContext> 
        where TModel : Entity
        where TDbContext : DbContext
    {
        private readonly TDbContext context;

        public Repository(TDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(
            Expression<Func<TModel, bool>> predicate = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null,
            int limit = default,
            bool enableTracking = true
            )
        {
            IQueryable<TModel> query = context.Set<TModel>();

            if (!enableTracking)
            {
                query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            query.Take(limit);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(
            int id,
            bool enableTracking = true,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null)
        {
            IQueryable<TModel> query = context.Set<TModel>();

            if (enableTracking == false)
            {
                query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.SingleOrDefaultAsync(t => t.Id == id);
        }

        public bool Exists(Expression<Func<TModel, bool>> predicate = null)
        {
            IQueryable<TModel> query = context.Set<TModel>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.Count() > 0;
        }

        public void Add(TModel model)
        {
            context.Add(model);
        }

        public void Update(TModel model)
        {
            context.Update(model);
        }

        public void Remove(TModel model)
        {
            context.Remove(model);
        }
    }
}

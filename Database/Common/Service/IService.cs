using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryManagement.Database.Common.Service
{
    public interface IService<TModel, TDbContext> 
        where TModel : Entity
        where TDbContext : DbContext
    {
        void Add(TModel model);
        Task<PagedResponse<TModel>> GetAllAsync(
            Expression<Func<TModel, bool>> predicate = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null,
            int pageNumber = default,
            int pageSize = default,
            bool enablePagination = false,
            bool enableTracking = true);
        Task<TModel> GetByIdAsync(int id, bool enableTracking = true, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null);
        void Remove(TModel model);
        void Update(TModel model);
    }
}
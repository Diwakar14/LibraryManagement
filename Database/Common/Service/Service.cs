using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryManagement.Database.Common.Service
{
    public class Service<TModel, TDbContext> : IService<TModel, TDbContext> where TModel : Entity where TDbContext : DbContext
    {
        private readonly IRepository<TModel, TDbContext> repository;

        public Service(IRepository<TModel, TDbContext> repository)
        {
            this.repository = repository;
        }

        public async Task<PagedResponse<TModel>> GetAllAsync(
            Expression<Func<TModel, bool>> predicate = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null,
            int pageNumber = default,
            int pageSize = default,
            bool enablePagination = false,
            bool enableTracking = true
            )
        {
            var list = await repository.GetAllAsync(predicate, orderBy, include, pageNumber, pageSize,enablePagination, enableTracking);
            return list;
        }

        public async Task<TModel> GetByIdAsync(int id,
            bool enableTracking = true,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
            )
        {
            var model = await repository.GetByIdAsync(id, enableTracking, include);
            return model;
        }

        public void Add(TModel model)
        {
            repository.Add(model);
        }

        public void Update(TModel model)
        {
            repository.Update(model);
        }

        public void Remove(TModel model)
        {
            repository.Remove(model);
        }
    }
}


using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database.Common.UnitOfWork
{
    public interface IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        void Dispose();
        Task SaveChangesAsync();
    }
}
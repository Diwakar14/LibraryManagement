using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database.Common.UnitOfWork
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}

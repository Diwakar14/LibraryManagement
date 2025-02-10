using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Models;

namespace LibraryManagement.Database.Service
{
    public class BatchFileService : Service<BatchFile, LibraryDbContext>, IBatchFileService
    {
        private readonly IRepository<BatchFile, LibraryDbContext> repository;
        private readonly IUnitOfWork<LibraryDbContext> unitOfWork;

        public BatchFileService(IRepository<BatchFile, LibraryDbContext> repository, IUnitOfWork<LibraryDbContext> unitOfWork) : base(repository)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

      

        public async Task<bool> Insert(IEnumerable<BatchFile> files)
        {
            foreach (var file in files)
            {
                this.repository.Add(file);
            }

            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

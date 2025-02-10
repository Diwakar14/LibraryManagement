using LibraryManagement.Models;

namespace LibraryManagement.Database.Service
{
    public interface IBatchFileService
    {
        Task<bool> Insert(IEnumerable<BatchFile> files);
        
    }
}
using LibraryManagement.Dtos.IssueBook;
using LibraryManagement.Dtos.Issuer;

namespace LibraryManagement.Database.Service
{
    public interface IIssuerService
    {
        Task<bool> CreateAsync(CreateIssuerDto createIssuerDto);
        Task<IEnumerable<IssuerDto>> GetAllAsync();
        Task<IssuerDto> GetByIdAsync(int id);
    }
}
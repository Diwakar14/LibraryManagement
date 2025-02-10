using LibraryManagement.Dtos.IssueBook;

namespace LibraryManagement.Database.Service
{
    public interface IIssueBookService
    {
        Task<bool> IssueBookAsync(CreateIssueBookDto createIssueBookDtos);
    }
}
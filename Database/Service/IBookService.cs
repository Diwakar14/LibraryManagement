using LibraryManagement.Dtos.Book;
using LibraryManagement.Models;

namespace LibraryManagement.Database.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        bool IsBookFileProcessed(string file);
        Task<bool> AddBookFileAsync(string file);
        Task<bool> AddBooksAsync(IEnumerable<Book> books, bool checkDuplicate = false); 
        Task<bool> AddBookAsync(CreateBookDto createBookDto);
        Task<BookDto> GetBookByIdAsync(int id);
        Task<bool> UpdateBookAsync(BookDto bookDto);
        Task<bool> UpdateBooksAsync(IEnumerable<Book> books);
    }
}
using AutoMapper;
using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Dtos.Book;
using LibraryManagement.Dtos.IssueBook;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using System.Collections.Concurrent;

namespace LibraryManagement.Database.Service
{
    public class IssueBookService : Service<BookIssuer, LibraryDbContext>, IIssueBookService
    {
        private readonly IRepository<BookIssuer, LibraryDbContext> repository;
        private readonly IBookService bookService;
        private readonly IIssuerService issuerService;
        private readonly IUnitOfWork<LibraryDbContext> unitOfWork;
        private readonly IMapper mapper;
        private static readonly Object lockObject = new Object();

        public IssueBookService(
            IRepository<BookIssuer, LibraryDbContext> repository,
            IBookService bookService,
            IIssuerService issuerService,
            IUnitOfWork<LibraryDbContext> unitOfWork,
            IMapper mapper) : base(repository)
        {
            this.repository = repository;
            this.bookService = bookService;
            this.issuerService = issuerService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> IssueBookAsync(CreateIssueBookDto createIssueBookDto)
        {
            try
            {
                //foreach (var createIssueBookDto in createIssueBookDtos)
                //{

                    var book = await bookService.GetBookByIdAsync(createIssueBookDto.BookId);
                    var issuer = await issuerService.GetByIdAsync(createIssueBookDto.IssuerId);

                    if (book == null)
                    {
                        throw new NotFoundException("Book not found");
                    }

                    if(issuer == null)
                    {
                        throw new NotFoundException("Issuer not found");
                    }
                    
                    if (book.Quantity < createIssueBookDto.Quantity)
                    {
                        throw new OutOfStockException("Book not available");
                    }

                    book.Quantity -= createIssueBookDto.Quantity;
                    await bookService.UpdateBookAsync(book);
                    var bookIssuer = new BookIssuer()
                    {
                        BookId = book.Id,
                        IssuerId = issuer.Id,
                    };
                    repository.Add(bookIssuer);
                //}

                await unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

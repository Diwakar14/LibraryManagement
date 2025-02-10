using AutoMapper;
using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Dtos;
using LibraryManagement.Dtos.Book;
using LibraryManagement.Extensions;
using LibraryManagement.Models;
using RedLockNet;

namespace LibraryManagement.Database.Service
{
    public class BookService : Service<Book, LibraryDbContext>, IBookService
    {
        private readonly IRepository<Book, LibraryDbContext> repository;
        private readonly IRepository<BatchFile, LibraryDbContext> batchFileRepository;
        private readonly IUnitOfWork<LibraryDbContext> unitOfWork;
        private readonly IMapper mapper;
        private readonly IDistributedLockFactory distributedLockFactory;

        public BookService(IRepository<Book, LibraryDbContext> repository,
            IRepository<BatchFile, LibraryDbContext> batchFileRepository,
            IUnitOfWork<LibraryDbContext> unitOfWork,
            IMapper mapper,
            IDistributedLockFactory distributedLockFactory) : base(repository)
        {
            this.repository = repository;
            this.batchFileRepository = batchFileRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.distributedLockFactory = distributedLockFactory;
        }

        public async Task<PagedResponseDto<BookDto>> GetBooksAsync(BookQueryParams queryParams)
        {
            await using var _lock = await distributedLockFactory.CreateLockAsync(
                nameof(GetBooksAsync), TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(1), TimeSpan.FromMilliseconds(10));

            if (_lock.IsAcquired)
            {
                var books = await repository.GetAllAsync(null, null, null, queryParams.pageNumber, queryParams.pageSize, true,false);
                var booksToDto = mapper.Map<PagedResponseDto<BookDto>>(books);
                return booksToDto;
            }

            throw new InvalidOperationException("Cannot aquire lock, try again later.");
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var books = await repository.GetByIdAsync(id);
            var booksToDto = mapper.Map<BookDto>(books);
            return booksToDto;
        }

        public bool IsBookFileProcessed(string file)
        {
            return batchFileRepository.Exists(e => e.FileName == file);
        }

        public async Task<bool> AddBookFileAsync(string file)
        {
            var batchFile = new BatchFile
            {
                FileName = file,
                Status = "Processed",
                Date = DateTime.Now,
            };
            batchFileRepository.Add(batchFile);

            await unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Add Books
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public async Task<bool> AddBooksAsync(IEnumerable<Book> books, bool duplicateCheck)
        {
            try
            {
             
                foreach (var book in books)
                {
                    if (duplicateCheck && books.IsExists(book))
                    {
                        continue;
                    }

                    repository.Add(book);
                }

                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddBookAsync(CreateBookDto createBookDto)
        {
            try
            {
                var book = mapper.Map<Models.Book>(createBookDto);
                repository.Add(book);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateBookAsync(BookDto bookDto)
        {
            try
            {
                var book = await repository.GetByIdAsync(bookDto.Id);
                var mappedBook = mapper.Map(bookDto, book);
                repository.Update(mappedBook);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> UpdateBooksAsync(IEnumerable<Models.Book> books)
        {
            try
            {
                foreach (var item in books)
                {
                    repository.Update(item);
                }

                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

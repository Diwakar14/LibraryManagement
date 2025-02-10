using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Database.Service;
using LibraryManagement.Database;
using LibraryManagement.Models;

namespace LibraryManagement.Extensions
{
    public static class ServiceCollectionExtention
    {
        public static void AddApplicationService(this IServiceCollection collection)
        {
            // Common Repository
            collection.AddScoped<IRepository<Book, LibraryDbContext>, Repository<Book, LibraryDbContext>>();
            collection.AddScoped<IRepository<Issuer, LibraryDbContext>, Repository<Issuer, LibraryDbContext>>();
            collection.AddScoped<IRepository<BookIssuer, LibraryDbContext>, Repository<BookIssuer, LibraryDbContext>>();
            collection.AddScoped<IRepository<BatchFile, LibraryDbContext>, Repository<BatchFile, LibraryDbContext>>();

            // Common Service
            collection.AddScoped<IService<Book, LibraryDbContext>, Service<Book, LibraryDbContext>>();
            collection.AddScoped<IService<Issuer, LibraryDbContext>, Service<Issuer, LibraryDbContext>>();
            collection.AddScoped<IService<BookIssuer, LibraryDbContext>, Service<BookIssuer, LibraryDbContext>>();
            collection.AddScoped<IService<BatchFile, LibraryDbContext>, Service<BatchFile, LibraryDbContext>>();

            // Common UnitOfWork
            collection.AddScoped<IUnitOfWork<LibraryDbContext>, UnitOfWork<LibraryDbContext>>();

            // Library Service
            collection.AddScoped<IBookService, BookService>();
            collection.AddScoped<IIssuerService, IssuerService>();
            collection.AddScoped<IIssueBookService, IssueBookService>();
            collection.AddScoped<IBatchFileService, BatchFileService>();
        }
    }
}

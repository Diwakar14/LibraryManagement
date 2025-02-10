
using Hangfire;
using LibraryManagement.Database;
using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Database.Service;
using LibraryManagement.Models;
using LibraryManagement.Redis;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;

namespace LibraryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

       
            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var redConnect = ConnectionMultiplexer.Connect("localhost");
            var redLockConnect = new List<RedLockMultiplexer> { redConnect };
            var redLockFactory = RedLockFactory.Create(redLockConnect);
            var connectionString = builder.Configuration.GetConnectionString("Default");
            var hangFireConnectionString = builder.Configuration.GetConnectionString("Hangfire");

            builder.Services.AddSingleton<IConnectionMultiplexer>(redConnect);
            builder.Services.AddSingleton<IDistributedLockFactory>(redLockFactory);
            builder.Services.AddScoped<IRedisService, RedisService>();

            builder.Services.AddSqlServer<LibraryDbContext>(builder.Configuration.GetConnectionString("Default"));

            builder.Services.AddHangfire((sp, config) =>
            {
                config.UseSqlServerStorage(connectionString);
            });

            builder.Services.AddHangfireServer();

            // Common Repository
            builder.Services.AddScoped<IRepository<Book, LibraryDbContext>, Repository<Book, LibraryDbContext>>();
            builder.Services.AddScoped<IRepository<Issuer, LibraryDbContext>, Repository<Issuer, LibraryDbContext>>();
            builder.Services.AddScoped<IRepository<BookIssuer, LibraryDbContext>, Repository<BookIssuer, LibraryDbContext>>();
            builder.Services.AddScoped<IRepository<BatchFile, LibraryDbContext>, Repository<BatchFile, LibraryDbContext>>();

            // Common Service
            builder.Services.AddScoped<IService<Book, LibraryDbContext>, Service<Book, LibraryDbContext>>();
            builder.Services.AddScoped<IService<Issuer, LibraryDbContext>, Service<Issuer, LibraryDbContext>>();
            builder.Services.AddScoped<IService<BookIssuer, LibraryDbContext>, Service<BookIssuer, LibraryDbContext>>();
            builder.Services.AddScoped<IService<BatchFile, LibraryDbContext>, Service<BatchFile, LibraryDbContext>>();

            // Common UnitOfWork
            builder.Services.AddScoped<IUnitOfWork<LibraryDbContext>, UnitOfWork<LibraryDbContext>>();

            // Library Service
            builder.Services.AddScoped<IBookService,  BookService>();
            builder.Services.AddScoped<IIssuerService,  IssuerService>();
            builder.Services.AddScoped<IIssueBookService, IssueBookService>();
            builder.Services.AddScoped<IBatchFileService, BatchFileService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


            
        }

        
    }
}

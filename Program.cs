
using Hangfire;
using LibraryManagement.Database;
using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Database.Service;
using LibraryManagement.Extensions;
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

            builder.Services.AddApplicationService();


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

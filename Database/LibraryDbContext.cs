using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Issuer> Issuers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookIssuer> BookIssuers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<BatchFile> BatchFiles { get; set; }
        public LibraryDbContext(DbContextOptions options) : base(options) 
        {
           
        }
    }
}

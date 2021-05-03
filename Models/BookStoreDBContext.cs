using Microsoft.EntityFrameworkCore;

namespace codeFirsto.Models
{
    public class BookStoreDBContext : DbContext
    {
        public DbSet<Publisher> Publishers {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<User> Users {get; set;}

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
        : base(options)
        {            
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=localhost;Database=BookStoresDB;User Id=sa;Password=@3T1snsb;");
        // }

    }
}
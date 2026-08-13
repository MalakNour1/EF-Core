using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.DbContexts;

public class BookStoreDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer
            ("Server = DESKTOP-EV6VD57\\MSSQLSERVER01; Database = bookstore; Trusted_Connection = True; TrustServerCertificate = True;");
    }
    public DbSet<Book>  Books { get; set; }
    public  DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    
}
using BOOKSTORE.DbContexts;

namespace BOOKSTORE;

class Program
{
    static void Main(string[] args)
    {
        var context = new BookStoreDbContext();
    }
}
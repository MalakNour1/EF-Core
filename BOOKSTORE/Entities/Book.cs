namespace BOOKSTORE.Entities;

public class Book
{
    public int Id { get; set; }
    public string ISBN { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int TotalPages { get; set; }
    public bool InStock { get; set; }
    public Author BookAuthor { get; set; } = null!;
    public Category Category { get; set; } = null!;
}
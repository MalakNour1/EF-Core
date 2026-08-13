namespace BOOKSTORE.Entities;
/*
information about the authors we work with, 
including their first and last names, 
email addresses, a short biography, 
and their date of birth. 
 */
public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ShortBio { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    
}
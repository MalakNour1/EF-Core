namespace EventHub.Entities;
/*
When a person or a company decides to host events through the platform, they
first register as an organizer by providing their name and, if applicable, the name
of the company they represent. 
The platform assigns each organizer a verified status after completing an
internal review process.
 */
using System.ComponentModel.DataAnnotations;

public class Organizer
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = null!;

    public ProfilePage Profile { get; set; } = null!;

    public ICollection<Event> Events { get; set; } = new List<Event>();
}
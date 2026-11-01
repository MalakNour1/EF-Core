namespace EventHub.Entities;

/*
Every organizer maintains a public-facing profile page
where they can write a short biography, link to their
personal or company website, and upload a logo.
This profile page is directly tied to the organizer’s account and cannot exist
without it.
*/

public class ProfilePage
{
    public int Id { get; set; }
    public string Biography { get; set; } = null!;
    public string LinkToWebsite { get; set; } = null!;
    public string Logo { get; set; } = null!;
    
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; } = null!;
}
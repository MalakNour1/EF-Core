using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EventHub.Entities;
/*
Each attendee provides their full name, an email address, and a home address that
includes a street, city, country, and postal code, used for correspondence
purposes. Once an attendee has registered for at least one event, the platform
issues them a badge — a credential uniquely numbered per attendee, stamped
with the date it was issued, and assigned a tier based on their registration
history: either Standard or VIP.

A badge belongs to one attendee, and each attendee can have at most one
badge.

An attendee can register for multiple events, and any given event will naturally
have many attendees signed up for it.
 */

[ Table ("EventOrganizers")]
public class Attendee
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    public string Street { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column("ZipCode")]
    public string PostalCode { get; set; } = null!;
    
    [NotMapped]
    public string FullAddress => $"{Street}, {City}, {Country}, {PostalCode}";
    public Badge? Badge { get; set; }

    public ICollection<Registration> Registrations { get; set; }
        = new List<Registration>();
}
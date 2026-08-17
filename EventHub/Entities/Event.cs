namespace EventHub.Entities;
/*
Every event carries a title, a detailed description, a start date, an optional end
date, and a maximum number of attendees allowed.

Large-scale events such as annual conferences may also contain smaller, more
focused sessions within them. For example, a technology conference might host
several breakout workshops on the same day, with each workshop treated as a
distinct event that is nested under the main conference event.

Sessions can only belong to one parent event, and a parent event can have any
number of sessions.
 */
public class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int MaxAttendees { get; set; }

    public int OrganizerId { get; set; }

    public Organizer Organizer { get; set; } = null!;

    // Self-referencing relationship
    public int? ParentEventId { get; set; }

    public Event? ParentEvent { get; set; }

    public ICollection<Event> Sessions { get; set; } = new List<Event>();

    public ICollection<Registration> Registrations { get; set; }
        = new List<Registration>();
}
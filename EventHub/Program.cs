namespace EventHub;
/*
EventHub is a platform that allows individuals and companies to organize,
promote, and manage public and private events.

Relationships:
1. Organizer — OrganizerProfile (One-to-One)
The case says:
This profile page is directly tied to the organizer’s account and cannot exist without it.
This tells us that every Profile must belong to an Organizer (Total on Profile side).

But does every Organizer have to have a Profile? The case doesn't explicitly say that an Organizer cannot exist without a Profile.
- Organizer: Partial
- OrganizerProfile: Total


2. Organizer — Event (One-to-Many)
The case says:
Once their account is set up, an organizer can publish events.

The word 'can' mean publishing events is possible, not mandatory.
- Organizer: Partial (an organizer can have zero events).
- Event: Total (each event must have an organizer who publishes it).


3. Attendee — Badge (One-to-One)
The case says:
The platform can issue an attendee a badge.

And:
A badge belongs to one attendee, and each attendee can have at most one badge.

The important phrase is can issue. It means an attendee doesn't necessarily need a badge.
- Attendee: Partial (can have zero or one badge).
- Badge: Total (every badge must belong to an attendee).
 */


class Program
{
    static void Main(string[] args)
    {
        
    }
}
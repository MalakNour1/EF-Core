using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.EndDate)
            .IsRequired(false);

        builder.Property(e => e.MaxAttendees)
            .IsRequired();

        // Organizer -> Events
        builder.HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Event -> Sessions
        builder.HasOne(e => e.ParentEvent)
            .WithMany(e => e.Sessions)
            .HasForeignKey(e => e.ParentEventId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // Shadow properties
        builder.Property<DateTime>("CreatedAt")
            .IsRequired();

        builder.Property<DateTime>("LastModifiedAt")
            .IsRequired();
    }
}
using EventHub.Configurations;
using EventHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHub.DbContexts;

public class EventHubDbContext : DbContext
{
    public DbSet<Organizer> Organizers => Set<Organizer>();
    public DbSet<ProfilePage> ProfilePages => Set<ProfilePage>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Attendee> Attendees => Set<Attendee>();
    public DbSet<Badge> Badges => Set<Badge>();
    public DbSet<Registration> Registrations => Set<Registration>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=.;" +
            "Database=EventHub;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(
            new ProfilePageConfiguration());

        modelBuilder.ApplyConfiguration(
            new BadgeConfiguration());

        modelBuilder.ApplyConfiguration(
            new EventConfiguration());

        // modelBuilder.ApplyConfiguration(
        //     new RegistrationConfiguration());
        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(r => new
            {
                r.AttendeeId,
                r.EventId
            });

            entity.Property(r => r.Note)
                .HasMaxLength(500)
                .IsRequired(false);

            entity.Property(r => r.RegisteredAt)
                .IsRequired();

            entity.HasOne(r => r.Attendee)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public override int SaveChanges()
    {
        UpdateEventTimestamps();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        UpdateEventTimestamps();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateEventTimestamps()
    {
        var entries = ChangeTracker
            .Entries<Event>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                entry.Property("LastModifiedAt").CurrentValue = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property("LastModifiedAt").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
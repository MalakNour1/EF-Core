using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.CredentialNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(b => b.CredentialNumber)
            .IsUnique();

        builder.Property(b => b.IssuedDate)
            .IsRequired();

        builder.Property(b => b.Tier)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasOne(b => b.Attendee)
            .WithOne(a => a.Badge)
            .HasForeignKey<Badge>(b => b.AttendeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
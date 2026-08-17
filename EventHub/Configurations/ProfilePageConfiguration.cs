using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations;

public class ProfilePageConfiguration : IEntityTypeConfiguration<ProfilePage>
{
    public void Configure(EntityTypeBuilder<ProfilePage> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Biography)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.LinkToWebsite)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(p => p.Logo)
            .IsRequired()
            .HasMaxLength(300);

        builder.HasOne(p => p.Organizer)
            .WithOne(o => o.Profile)
            .HasForeignKey<ProfilePage>(p => p.OrganizerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
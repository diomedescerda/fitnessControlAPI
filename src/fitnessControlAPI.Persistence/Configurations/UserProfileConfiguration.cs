using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Persistence.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("users");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(e => e.IdentityUserId)
            .IsRequired();
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(e => e.Height)
            .IsRequired()
            .HasPrecision(5,2);
        builder.Property(e => e.BirthDate)
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.HasIndex(e => e.IdentityUserId)
            .IsUnique();
        builder.HasOne<AppUser>()
            .WithOne()
            .HasForeignKey<UserProfile>(e => e.IdentityUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
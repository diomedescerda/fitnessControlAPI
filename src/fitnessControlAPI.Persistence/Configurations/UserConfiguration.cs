using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
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
    }
}
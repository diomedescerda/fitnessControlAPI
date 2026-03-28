using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class BodyMeasurementConfiguration : IEntityTypeConfiguration<BodyMeasurement>
{
    public void Configure(EntityTypeBuilder<BodyMeasurement> builder)
    {
        builder.ToTable("body_measurements");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(e => e.UserId)
            .IsRequired();
        builder.Property(e => e.RecordedDate)
            .IsRequired()
            .HasDefaultValue("CURRENT_DATE");
        builder.Property(e => e.Weight)
            .IsRequired()
            .HasPrecision(5,2);
        builder.Property(e => e.Chest)
            .HasPrecision(5,2);
        builder.Property(e => e.Waist)
            .HasPrecision(5,2);
        builder.Property(e => e.Hips)
            .HasPrecision(5,2);
        builder.Property(e => e.Bicep)
            .HasPrecision(5,2);
        builder.Property(e => e.Thigh)
            .HasPrecision(5,2);
        builder.Property(e => e.Calf)
            .HasPrecision(5,2);
        builder.Property(e => e.Notes)
            .HasMaxLength(500);
            
        builder.HasIndex(e => new { e.UserId, e.RecordedDate })
            .IsUnique()
            .HasDatabaseName("ix_body_measurements_user_id_recorded_date");
        
        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
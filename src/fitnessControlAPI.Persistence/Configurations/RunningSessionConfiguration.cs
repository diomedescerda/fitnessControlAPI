using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class RunningSessionConfiguration : IEntityTypeConfiguration<RunningSession>
{
    public void Configure(EntityTypeBuilder<RunningSession> builder)
    {
        builder.ToTable("running_sessions");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(e => e.UserId)
            .IsRequired();
        builder.Property(e => e.Date)
            .IsRequired();
        builder.Property(e => e.Distance)
            .IsRequired();
        builder.Property(e => e.Duration)
            .IsRequired();
        builder.Property(e => e.AvgPace)
            .IsRequired();
        builder.Property(e => e.AvgHeartRate);
        builder.Property(e => e.MaxHeartRate);
        builder.Property(e => e.CaloriesBurned);
        builder.Property(e => e.Notes);
        
        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.ToTable("workout_exercises");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(e => e.WorkoutSessionId)
            .IsRequired();
        builder.Property(e => e.ExerciseId)
            .IsRequired();
        builder.Property(e => e.OrderNumber)
            .IsRequired();
        builder.Property(e => e.Notes)
            .HasMaxLength(500);
        
        builder.HasIndex(e => new { e.WorkoutSessionId, e.OrderNumber })
            .IsUnique()
            .HasDatabaseName("ix_workout_exercise_sets_workout_exercise_id_order_number");
        
        builder.HasOne(e => e.WorkoutSession)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(e => e.WorkoutSessionId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(e => e.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
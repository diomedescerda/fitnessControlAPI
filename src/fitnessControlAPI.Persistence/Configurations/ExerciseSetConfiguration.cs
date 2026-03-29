using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class ExerciseSetConfiguration : IEntityTypeConfiguration<ExerciseSet>
{
    public void Configure(EntityTypeBuilder<ExerciseSet> builder)
    {
        builder.ToTable("exercise_sets");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        builder.Property(e => e.WorkoutExerciseId)
            .IsRequired();
        builder.Property(e => e.SetNumber)
            .IsRequired();
        builder.Property(e => e.SetNumber)
            .IsRequired();
        builder.Property(e => e.Weight)
            .IsRequired()
            .HasPrecision(6,2);
        builder.Property(e => e.Comment);
        
        builder.HasIndex(e => new { e.WorkoutExerciseId, e.SetNumber })
            .IsUnique()
            .HasDatabaseName("ix_exercise_sets_workout_exercise_id_set_number");
        
        builder.HasOne(e => e.WorkoutExercise)
            .WithMany(e => e.ExerciseSets)
            .HasForeignKey(e => e.WorkoutExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
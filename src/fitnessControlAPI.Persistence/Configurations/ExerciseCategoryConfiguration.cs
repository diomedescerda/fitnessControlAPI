using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessControlAPI.Persistence.Configurations;

public class ExerciseCategoryConfiguration : IEntityTypeConfiguration<ExerciseCategory>
{
    public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
    {
        builder.ToTable("exercise_categories");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .UseIdentityColumn();
            
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.HasIndex(e => e.Name)
            .IsUnique();
            
        builder.Property(e => e.Description)
            .HasMaxLength(500);
    }
}
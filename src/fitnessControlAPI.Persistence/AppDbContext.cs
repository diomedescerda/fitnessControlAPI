using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence;

public class AppDbContext : DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }
   
   public DbSet<MuscleGroup>  MuscleGroups { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<MuscleGroup>(entity =>
      {
         entity.ToTable("muscle_groups");
         entity.HasKey(e => e.Id);
         entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
      });
   }
}
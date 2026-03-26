using fitnessControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MuscleGroup>  MuscleGroups { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       foreach (var entity in modelBuilder.Model.GetEntityTypes())
       {
           entity.SetTableName(entity.GetTableName()?.ToSnakeCase());

           foreach (var property in entity.GetProperties())
           {
               property.SetColumnName(property.GetColumnName().ToSnakeCase());
           }

           foreach (var key in entity.GetKeys())
           {
               key.SetName(key.GetName()?.ToSnakeCase());
           }

           foreach (var foreignKey in entity.GetForeignKeys())
           {
               foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToSnakeCase());
           }
       }

      modelBuilder.Entity<MuscleGroup>(entity =>
      {
         entity.ToTable("muscle_groups");
         entity.HasKey(e => e.Id);
         entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
      });
   }
}

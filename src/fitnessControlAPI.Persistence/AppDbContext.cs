using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BodyMeasurement>  BodyMeasurements { get; set; }
    public DbSet<ExerciseCategory>  ExerciseCategories { get; set; }
    public DbSet<Exercise>  Exercises { get; set; }
    public DbSet<ExerciseSet>  ExerciseSets { get; set; }
    public DbSet<MuscleGroup>  MuscleGroups { get; set; }
    public DbSet<RunningSession>  RunningSessions { get; set; }
    public DbSet<User>  Users { get; set; }
    public DbSet<WorkoutExercise>  WorkoutExercises { get; set; }
    public DbSet<WorkoutSession>  WorkoutSessions { get; set; }

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
       
       modelBuilder.ApplyConfiguration(new BodyMeasurementConfiguration());
       modelBuilder.ApplyConfiguration(new ExerciseCategoryConfiguration());
       modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
       modelBuilder.ApplyConfiguration(new ExerciseSetConfiguration());
       modelBuilder.ApplyConfiguration(new MuscleGroupConfiguration());
       modelBuilder.ApplyConfiguration(new RunningSessionConfiguration());
       modelBuilder.ApplyConfiguration(new UserConfiguration());
       modelBuilder.ApplyConfiguration(new WorkoutExerciseConfiguration());
       modelBuilder.ApplyConfiguration(new WorkoutSessionConfiguration());
   }
}

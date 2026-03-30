using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class WorkoutExerciseRepository(AppDbContext context) : IWorkoutExerciseRepository
{
   public async Task<IEnumerable<WorkoutExercise>> GetAllAsync()
   {
      return await context.WorkoutExercises.ToListAsync();
   }

   public async Task<WorkoutExercise?> GetByIdAsync(Guid id)
   {
      return await context.WorkoutExercises.FindAsync(id);
   }
   
   public async Task<WorkoutExercise> CreateAsync(WorkoutExercise workoutExercise)
   {
      var entry = await context.WorkoutExercises.AddAsync(workoutExercise);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(WorkoutExercise workoutExercise)
   {
      context.WorkoutExercises.Update(workoutExercise);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(Guid id)
   {
      var workoutExercise = await context.WorkoutExercises.FindAsync(id);
      if (workoutExercise is null) return;
      context.WorkoutExercises.Remove(workoutExercise);
      await context.SaveChangesAsync();
   }
}
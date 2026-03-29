using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class ExerciseRepository(AppDbContext context) : IExerciseRepository
{
   public async Task<IEnumerable<Exercise>> GetAllAsync()
   {
      return await context.Exercises.ToListAsync();
   }

   public async Task<Exercise?> GetByIdAsync(int id)
   {
      return await context.Exercises.FindAsync(id);
   }
   
   public async Task<Exercise> CreateAsync(Exercise exercise)
   {
      var entry = await context.Exercises.AddAsync(exercise);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(Exercise exercise)
   {
      context.Exercises.Update(exercise);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(int id)
   {
      var exercise = await context.Exercises.FindAsync(id);
      if (exercise is null) return;
      context.Exercises.Remove(exercise);
      await context.SaveChangesAsync();
   }
}
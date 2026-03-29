using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class ExerciseSetRepository(AppDbContext context) : IExerciseSetRepository
{
   public async Task<IEnumerable<ExerciseSet>> GetAllAsync()
   {
      return await context.ExerciseSets.ToListAsync();
   }

   public async Task<ExerciseSet?> GetByIdAsync(int id)
   {
      return await context.ExerciseSets.FindAsync(id);
   }
   
   public async Task<ExerciseSet> CreateAsync(ExerciseSet exerciseSet)
   {
      var entry = await context.ExerciseSets.AddAsync(exerciseSet);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(ExerciseSet exerciseSet)
   {
      context.ExerciseSets.Update(exerciseSet);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(int id)
   {
      var exerciseSet = await context.ExerciseSets.FindAsync(id);
      if (exerciseSet is null) return;
      context.ExerciseSets.Remove(exerciseSet);
      await context.SaveChangesAsync();
   }
}
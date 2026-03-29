using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class ExerciseCategoryRepository(AppDbContext context) : IExerciseCategoryRepository
{
   public async Task<IEnumerable<ExerciseCategory>> GetAllAsync()
   {
      return await context.ExerciseCategories.ToListAsync();
   }

   public async Task<ExerciseCategory?> GetByIdAsync(int id)
   {
      return await context.ExerciseCategories.FindAsync(id);
   }
   
   public async Task<ExerciseCategory> CreateAsync(ExerciseCategory exerciseCategory)
   {
      var entry = await context.ExerciseCategories.AddAsync(exerciseCategory);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(ExerciseCategory exerciseCategory)
   {
      context.ExerciseCategories.Update(exerciseCategory);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(int id)
   {
      var exerciseCategory = await context.ExerciseCategories.FindAsync(id);
      if (exerciseCategory is null) return;
      context.ExerciseCategories.Remove(exerciseCategory);
      await context.SaveChangesAsync();
   }
}
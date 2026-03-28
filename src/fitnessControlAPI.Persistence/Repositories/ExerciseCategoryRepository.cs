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
}
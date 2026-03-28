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
}
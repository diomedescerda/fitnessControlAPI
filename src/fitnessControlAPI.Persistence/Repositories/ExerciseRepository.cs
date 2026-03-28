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
}
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

   public async Task<WorkoutExercise?> GetByIdAsync(int id)
   {
      return await context.WorkoutExercises.FindAsync(id);
   }
}
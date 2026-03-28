using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class WorkoutSessionRepository(AppDbContext context) : IWorkoutSessionRepository
{
   public async Task<IEnumerable<WorkoutSession>> GetAllAsync()
   {
      return await context.WorkoutSessions.ToListAsync();
   }

   public async Task<WorkoutSession?> GetByIdAsync(int id)
   {
      return await context.WorkoutSessions.FindAsync(id);
   }
}
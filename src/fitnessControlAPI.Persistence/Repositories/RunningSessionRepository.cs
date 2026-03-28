using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class RunningSessionRepository(AppDbContext context) : IRunningSessionRepository
{
   public async Task<IEnumerable<RunningSession>> GetAllAsync()
   {
      return await context.RunningSessions.ToListAsync();
   }

   public async Task<RunningSession?> GetByIdAsync(int id)
   {
      return await context.RunningSessions.FindAsync(id);
   }
}
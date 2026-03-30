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

   public async Task<RunningSession?> GetByIdAsync(Guid id)
   {
      return await context.RunningSessions.FindAsync(id);
   }
   
   public async Task<RunningSession> CreateAsync(RunningSession runningSession)
   {
      var entry = await context.RunningSessions.AddAsync(runningSession);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(RunningSession runningSession)
   {
      context.RunningSessions.Update(runningSession);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(Guid id)
   {
      var runningSession = await context.RunningSessions.FindAsync(id);
      if (runningSession is null) return;
      context.RunningSessions.Remove(runningSession);
      await context.SaveChangesAsync();
   }
}
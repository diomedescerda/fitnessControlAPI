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

   public async Task<WorkoutSession?> GetByIdAsync(Guid id)
   {
      return await context.WorkoutSessions.FindAsync(id);
   }

   public async Task<int> GetNoGymSessionsByUserIdAndOffsetAsync(Guid userId, int offset)
   {
       var today = DateOnly.FromDateTime(DateTime.Today);
       var startOfWeek = today.AddDays(-(int)today.DayOfWeek - offset * 7);
       var endOfWeek = startOfWeek.AddDays(7);

       return await context.WorkoutSessions
           .Where(b => b.UserId == userId)
           .Where(b => b.Date >= startOfWeek && b.Date <= endOfWeek)
           .CountAsync();
   }
   
   public async Task<WorkoutSession> CreateAsync(WorkoutSession workoutSession)
   {
      var entry = await context.WorkoutSessions.AddAsync(workoutSession);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(WorkoutSession workoutSession)
   {
      context.WorkoutSessions.Update(workoutSession);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(Guid id)
   {
      var workoutSession = await context.WorkoutSessions.FindAsync(id);
      if (workoutSession is null) return;
      context.WorkoutSessions.Remove(workoutSession);
      await context.SaveChangesAsync();
   }
}

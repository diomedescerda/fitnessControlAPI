using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class MuscleGroupRepository(AppDbContext context) : IMuscleGroupRepository
{
   public async Task<IEnumerable<MuscleGroup>> GetAllAsync()
   {
      return await context.MuscleGroups.ToListAsync();
   }

   public async Task<MuscleGroup?> GetByIdAsync(int id)
   {
      return await context.MuscleGroups.FindAsync(id);
   }

   public async Task<MuscleGroup> CreateAsync(MuscleGroup muscleGroup)
   {
      var entry = await context.MuscleGroups.AddAsync(muscleGroup);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(MuscleGroup muscleGroup)
   {
      context.MuscleGroups.Update(muscleGroup);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(int id)
   {
       var muscleGroup = await context.MuscleGroups.FindAsync(id);
       if (muscleGroup is null) return;
       context.MuscleGroups.Remove(muscleGroup);
       await context.SaveChangesAsync();
   }
}
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
}
using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class BodyMeasurementRepository(AppDbContext context) : IBodyMeasurementRepository
{
   public async Task<IEnumerable<BodyMeasurement>> GetAllAsync()
   {
      return await context.BodyMeasurements.ToListAsync();
   }

   public async Task<BodyMeasurement?> GetByIdAsync(int id)
   {
      return await context.BodyMeasurements.FindAsync(id);
   }
}
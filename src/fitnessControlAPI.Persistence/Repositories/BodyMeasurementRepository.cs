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

   public async Task<BodyMeasurement?> GetByIdAsync(Guid id)
   {
      return await context.BodyMeasurements.FindAsync(id);
   }
   
   public async Task<BodyMeasurement> CreateAsync(BodyMeasurement bodyMeasurement)
   {
      var entry = await context.BodyMeasurements.AddAsync(bodyMeasurement);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(BodyMeasurement bodyMeasurement)
   {
      context.BodyMeasurements.Update(bodyMeasurement);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(Guid id)
   {
      var bodyMeasurement = await context.BodyMeasurements.FindAsync(id);
      if (bodyMeasurement is null) return;
      context.BodyMeasurements.Remove(bodyMeasurement);
      await context.SaveChangesAsync();
   }
}
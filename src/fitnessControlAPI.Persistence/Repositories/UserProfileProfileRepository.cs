using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class UserProfileProfileRepository(AppDbContext context) : IUserProfileRepository
{
   public async Task<IEnumerable<UserProfile>> GetAllAsync()
   {
      return await context.UserProfiles.ToListAsync();
   }

   public async Task<UserProfile?> GetByIdAsync(Guid id)
   {
      return await context.UserProfiles.FindAsync(id);
   }
   
   public async Task<UserProfile> CreateAsync(UserProfile userProfile)
   {
      var entry = await context.UserProfiles.AddAsync(userProfile);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(UserProfile userProfile)
   {
      context.UserProfiles.Update(userProfile);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(Guid id)
   {
      var user = await context.UserProfiles.FindAsync(id);
      if (user is null) return;
      context.UserProfiles.Remove(user);
      await context.SaveChangesAsync();
   }
}
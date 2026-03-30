using fitnessControlAPI.Domain.Entities;
using fitnessControlAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fitnessControlAPI.Persistence.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
   public async Task<IEnumerable<User>> GetAllAsync()
   {
      return await context.Users.ToListAsync();
   }

   public async Task<User?> GetByIdAsync(Guid id)
   {
      return await context.Users.FindAsync(id);
   }
   
   public async Task<User> CreateAsync(User user)
   {
      var entry = await context.Users.AddAsync(user);
      await context.SaveChangesAsync();
      return entry.Entity;
   }

   public async Task UpdateAsync(User user)
   {
      context.Users.Update(user);
      await context.SaveChangesAsync();
   }

   public async Task DeleteAsync(Guid id)
   {
      var user = await context.Users.FindAsync(id);
      if (user is null) return;
      context.Users.Remove(user);
      await context.SaveChangesAsync();
   }
}
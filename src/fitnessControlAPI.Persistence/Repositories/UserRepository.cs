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

   public async Task<User?> GetByIdAsync(int id)
   {
      return await context.Users.FindAsync(id);
   }
}
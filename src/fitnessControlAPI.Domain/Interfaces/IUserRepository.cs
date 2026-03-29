using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}
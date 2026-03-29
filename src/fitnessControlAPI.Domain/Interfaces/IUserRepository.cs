using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    void CreateAsync(User user);
    void UpdateAsync(User user);
    void DeleteAsync(int id);
    void SaveAsync();
}
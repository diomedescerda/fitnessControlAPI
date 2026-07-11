using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile> CreateAsync(UserProfile userProfile);
    Task<IEnumerable<UserProfile>> GetAllAsync();
    Task<UserProfile?> GetByIdAsync(Guid id);
    Task UpdateAsync(UserProfile userProfile);
    Task DeleteAsync(Guid id);
}
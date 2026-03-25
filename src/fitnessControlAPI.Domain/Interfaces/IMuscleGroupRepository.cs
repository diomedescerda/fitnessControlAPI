using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IMuscleGroupRepository
{
    Task<IEnumerable<MuscleGroup>> GetAllAsync();
    Task<MuscleGroup?> GetByIdAsync(int id);
}
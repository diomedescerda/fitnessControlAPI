using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IMuscleGroupRepository
{
    Task<MuscleGroup> CreateAsync(MuscleGroup muscleGroup);
    Task<IEnumerable<MuscleGroup>> GetAllAsync();
    Task<MuscleGroup?> GetByIdAsync(int id);
    Task UpdateAsync(MuscleGroup muscleGroup);
    Task DeleteAsync(int id);
}
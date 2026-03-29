using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IMuscleGroupRepository
{
    Task<IEnumerable<MuscleGroup>> GetAllAsync();
    Task<MuscleGroup?> GetByIdAsync(int id);
    void CreateAsync(MuscleGroup muscleGroup);
    void UpdateAsync(MuscleGroup muscleGroup);
    void DeleteAsync(int id);
    void SaveAsync();
}
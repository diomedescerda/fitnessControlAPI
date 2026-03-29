using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise?> GetByIdAsync(int id);
    void CreateAsync(Exercise exercise);
    void UpdateAsync(Exercise exercise);
    void DeleteAsync(int id);
    void SaveAsync();
}
using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseRepository
{
    Task<Exercise> CreateAsync(Exercise exercise);
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise?> GetByIdAsync(int id);
    Task UpdateAsync(Exercise exercise);
    Task DeleteAsync(int id);
}
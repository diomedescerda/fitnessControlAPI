using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseSetRepository
{
    Task CreateAsync(ExerciseSet exerciseSet);
    Task<IEnumerable<ExerciseSet>> GetAllAsync();
    Task<ExerciseSet?> GetByIdAsync(int id);
    Task UpdateAsync(ExerciseSet exerciseSet);
    Task DeleteAsync(int id);
}
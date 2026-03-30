using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseSetRepository
{
    Task<ExerciseSet> CreateAsync(ExerciseSet exerciseSet);
    Task<IEnumerable<ExerciseSet>> GetAllAsync();
    Task<ExerciseSet?> GetByIdAsync(Guid id);
    Task UpdateAsync(ExerciseSet exerciseSet);
    Task DeleteAsync(Guid id);
}
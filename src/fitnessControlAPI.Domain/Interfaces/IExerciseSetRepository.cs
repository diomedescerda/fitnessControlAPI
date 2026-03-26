using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseSetRepository
{
    Task<IEnumerable<ExerciseSet>> GetAllAsync();
    Task<ExerciseSet?> GetByIdAsync(int id);
}
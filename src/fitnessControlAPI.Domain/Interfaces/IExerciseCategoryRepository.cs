using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseCategoryRepository
{
    Task<IEnumerable<ExerciseCategory>> GetAllAsync();
    Task<ExerciseCategory?> GetByIdAsync(int id);
}
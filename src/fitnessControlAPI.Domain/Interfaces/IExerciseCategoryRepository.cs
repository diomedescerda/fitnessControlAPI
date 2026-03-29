using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseCategoryRepository
{
    Task CreateAsync(ExerciseCategory exerciseCategory);
    Task<IEnumerable<ExerciseCategory>> GetAllAsync();
    Task<ExerciseCategory?> GetByIdAsync(int id);
    Task UpdateAsync(ExerciseCategory exerciseCategory);
    Task DeleteAsync(int id);
}
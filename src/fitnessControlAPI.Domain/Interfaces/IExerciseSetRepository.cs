using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IExerciseSetRepository
{
    Task<IEnumerable<ExerciseSet>> GetAllAsync();
    Task<ExerciseSet?> GetByIdAsync(int id);
    void CreateAsync(ExerciseSet exerciseSet);
    void UpdateAsync(ExerciseSet exerciseSet);
    void DeleteAsync(int id);
    void SaveAsync();
}
using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutExerciseRepository
{
    Task<IEnumerable<WorkoutExercise>> GetAllAsync();
    Task<WorkoutExercise?> GetByIdAsync(int id);
    void CreateAsync(WorkoutExercise workoutExercise);
    void UpdateAsync(WorkoutExercise workoutExercise);
    void DeleteAsync(int id);
    void SaveAsync();
}
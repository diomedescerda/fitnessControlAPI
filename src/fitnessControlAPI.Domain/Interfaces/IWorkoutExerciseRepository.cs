using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutExerciseRepository
{
    Task CreateAsync(WorkoutExercise workoutExercise);
    Task<IEnumerable<WorkoutExercise>> GetAllAsync();
    Task<WorkoutExercise?> GetByIdAsync(int id);
    Task UpdateAsync(WorkoutExercise workoutExercise);
    Task DeleteAsync(int id);
}
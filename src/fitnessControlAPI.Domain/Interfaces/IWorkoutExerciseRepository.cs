using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutExerciseRepository
{
    Task<WorkoutExercise> CreateAsync(WorkoutExercise workoutExercise);
    Task<IEnumerable<WorkoutExercise>> GetAllAsync();
    Task<WorkoutExercise?> GetByIdAsync(Guid id);
    Task UpdateAsync(WorkoutExercise workoutExercise);
    Task DeleteAsync(Guid id);
}
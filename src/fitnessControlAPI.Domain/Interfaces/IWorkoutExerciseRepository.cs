using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutExerciseRepository
{
    Task<IEnumerable<WorkoutExercise>> GetAllAsync();
    Task<WorkoutExercise?> GetByIdAsync(int id);
}
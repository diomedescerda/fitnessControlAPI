using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutSessionRepository
{
    Task CreateAsync(WorkoutSession workoutSession);
    Task<IEnumerable<WorkoutSession>> GetAllAsync();
    Task<WorkoutSession?> GetByIdAsync(int id);
    Task UpdateAsync(WorkoutSession workoutSession);
    Task DeleteAsync(int id);
}
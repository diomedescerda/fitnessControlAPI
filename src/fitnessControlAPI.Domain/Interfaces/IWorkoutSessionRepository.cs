using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutSessionRepository
{
    Task<IEnumerable<WorkoutSession>> GetAllAsync();
    Task<WorkoutSession?> GetByIdAsync(int id);
    void CreateAsync(WorkoutSession workoutSession);
    void UpdateAsync(WorkoutSession workoutSession);
    void DeleteAsync(int id);
    void SaveAsync();
}
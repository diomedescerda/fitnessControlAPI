using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IWorkoutSessionRepository
{
    Task<WorkoutSession> CreateAsync(WorkoutSession workoutSession);
    Task<IEnumerable<WorkoutSession>> GetAllAsync();
    Task<WorkoutSession?> GetByIdAsync(Guid id);
    Task<int> GetNoGymSessionsByUserIdAndOffsetAsync(Guid userId, int offset);
    Task<IEnumerable<WorkoutSession>> GetLastWorkoutSessionsByUserIdAndNAsync(Guid userId, int n);
    Task UpdateAsync(WorkoutSession workoutSession);
    Task DeleteAsync(Guid id);
}

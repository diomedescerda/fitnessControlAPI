using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IRunningSessionRepository
{
    Task<RunningSession> CreateAsync(RunningSession runningSession);
    Task<IEnumerable<RunningSession>> GetAllAsync();
    Task<RunningSession?> GetByIdAsync(Guid id);
    Task<decimal> GetWeeklyDistanceByUserIdAndOffsetAsync(Guid userId, int offset);
    Task UpdateAsync(RunningSession runningSession);
    Task DeleteAsync(Guid id);
}

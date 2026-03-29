using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IRunningSessionRepository
{
    Task CreateAsync(RunningSession runningSession);
    Task<IEnumerable<RunningSession>> GetAllAsync();
    Task<RunningSession?> GetByIdAsync(int id);
    Task UpdateAsync(RunningSession runningSession);
    Task DeleteAsync(int id);
}
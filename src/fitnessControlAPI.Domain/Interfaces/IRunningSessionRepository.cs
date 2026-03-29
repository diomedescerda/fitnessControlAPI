using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IRunningSessionRepository
{
    Task<IEnumerable<RunningSession>> GetAllAsync();
    Task<RunningSession?> GetByIdAsync(int id);
    void CreateAsync(RunningSession runningSession);
    void UpdateAsync(RunningSession runningSession);
    void DeleteAsync(int id);
    void SaveAsync();
}
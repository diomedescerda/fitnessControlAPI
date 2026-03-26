using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IRunningSessionRepository
{
    Task<IEnumerable<RunningSession>> GetAllAsync();
    Task<RunningSession?> GetByIdAsync(int id);
}
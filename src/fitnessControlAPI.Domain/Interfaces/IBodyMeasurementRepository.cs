using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IBodyMeasurementRepository
{
    Task<BodyMeasurement> CreateAsync(BodyMeasurement bodyMeasurement);
    Task<IEnumerable<BodyMeasurement>> GetAllAsync();
    Task<BodyMeasurement?> GetByIdAsync(Guid id);
    Task<BodyMeasurement?> GetMostRecentByUserIdAsync(Guid id);
    Task UpdateAsync(BodyMeasurement bodyMeasurement);
    Task DeleteAsync(Guid id);
}

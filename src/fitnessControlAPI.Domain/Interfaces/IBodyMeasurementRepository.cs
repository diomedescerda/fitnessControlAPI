using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IBodyMeasurementRepository
{
    Task CreateAsync(BodyMeasurement bodyMeasurement);
    Task<IEnumerable<BodyMeasurement>> GetAllAsync();
    Task<BodyMeasurement?> GetByIdAsync(int id);
    Task UpdateAsync(BodyMeasurement bodyMeasurement);
    Task DeleteAsync(int id);
}
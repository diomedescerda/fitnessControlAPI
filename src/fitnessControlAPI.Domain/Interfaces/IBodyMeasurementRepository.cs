using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IBodyMeasurementRepository
{
    Task<IEnumerable<BodyMeasurement>> GetAllAsync();
    Task<BodyMeasurement?> GetByIdAsync(int id);
}
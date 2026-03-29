using fitnessControlAPI.Domain.Entities;

namespace fitnessControlAPI.Domain.Interfaces;

public interface IBodyMeasurementRepository
{
    Task<IEnumerable<BodyMeasurement>> GetAllAsync();
    Task<BodyMeasurement?> GetByIdAsync(int id);
    void CreateAsync(BodyMeasurement bodyMeasurement);
    void UpdateAsync(BodyMeasurement bodyMeasurement);
    void DeleteAsync(int id);
    void SaveAsync();
}
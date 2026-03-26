namespace fitnessControlAPI.Domain.Entities;

public class BodyMeasurement
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required DateOnly RecordedDate { get; set; }
    public required decimal Weight { get; set; }
    public decimal? Chest { get; set; }
    public decimal? Waist { get; set;}
    public decimal? Hips { get; set;}
    public decimal? Bicep { get; set;}
    public decimal? Thigh { get; set;}
    public decimal? Calf { get; set;}
    public string? Notes { get; set;}
}
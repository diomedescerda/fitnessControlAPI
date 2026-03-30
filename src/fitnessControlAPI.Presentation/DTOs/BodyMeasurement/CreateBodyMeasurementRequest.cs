namespace fitnessControlAPI.Presentation.DTOs.BodyMeasurement;

public class CreateBodyMeasurementRequest
{
    public required Guid UserId { get; set; }
    public required DateOnly Date { get; set; }
    public required decimal Weight { get; set; }
    public decimal? Chest { get; set; }
    public decimal? Waist { get; set;}
    public decimal? Hips { get; set;}
    public decimal? Bicep { get; set;}
    public decimal? Thigh { get; set;}
    public decimal? Calf { get; set;}
    public string? Notes { get; set;}
}
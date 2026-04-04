namespace fitnessControlAPI.Presentation.DTOs.RunningSession;

public class RunningSessionResponse {
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Date { get; set; }
    public required decimal Distance { get; set; }
    public required TimeSpan Duration { get; set; }
    public required TimeSpan AvgPace { get; set; }
    public int? AvgHeartRate { get; set; }
    public int? MaxHeartRate { get; set; }
    public int? CaloriesBurned { get; set; }
    public string? Notes { get; set; }
}

namespace fitnessControlAPI.Domain.Entities;

public class RunningSession
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required DateOnly Date { get; set; }
    public required decimal Distance { get; set; }
    public required TimeSpan Duration { get; set; }
    public TimeSpan? AvgPace { get; set; }
    public int? AvgHeartRate { get; set; }
    public int? MaxHeartRate { get; set; }
    public int? CaloriesBurned { get; set; }
    public string? Notes { get; set; }
    
    public User? User { get; set; }
}

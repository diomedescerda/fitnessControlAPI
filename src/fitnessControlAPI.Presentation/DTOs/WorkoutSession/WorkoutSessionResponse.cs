namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class WorkoutSessionResponse
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required DateOnly Date { get; set; }
    public string? Notes { get; set; }
}

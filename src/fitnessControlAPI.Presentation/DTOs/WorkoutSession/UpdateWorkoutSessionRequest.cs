namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class UpdateWorkoutSessionRequest
{
    public required Guid UserId { get; set; }
    public required DateOnly Date { get; set; }
    public string? Notes { get; set; }
}

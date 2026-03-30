namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class WorkoutExerciseResponse
{
    public Guid Id { get; set; }
    public required Guid WorkoutSessionId { get; set; }
    public required int ExerciseId { get; set; }
    public required int OrderNumber { get; set; }
    public string? Notes { get; set; }
}

namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class UpdateWorkoutExerciseRequest
{
    public required Guid WorkoutSessionId { get; set; }
    public required int ExerciseId { get; set; }
    public required int OrderNumber { get; set; }
    public string? Notes { get; set; }
}

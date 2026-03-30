namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class CreateWorkoutExerciseRequest
{
    public required Guid WorkoutSessionId { get; set; }
    public required int ExerciseId { get; set; }
    public required int OrderNumber { get; set; }
    public string? Notes { get; set; }
}

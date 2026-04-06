namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class CreateJoinedWorkoutExerciseRequest
{
    public required int ExerciseId { get; set; }
    public required int OrderNumber { get; set; }
    public string? Notes { get; set; }

    public ICollection<CreateJoinedExerciseSetRequest> ExerciseSets { get; set; } = new List<CreateJoinedExerciseSetRequest>();
}

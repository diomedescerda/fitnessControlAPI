namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class CreateWorkoutSessionRequest
{
    public required Guid UserId { get; set; }
    public required DateOnly Date { get; set; }
    public string? Notes { get; set; }

    public ICollection<CreateJoinedWorkoutExerciseRequest> WorkoutExercises { get; set; } = new List<CreateJoinedWorkoutExerciseRequest>();
}

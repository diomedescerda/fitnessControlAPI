namespace fitnessControlAPI.Presentation.DTOs.WorkoutSession;

public class CreateJoinedExerciseSetRequest {
    public required int SetNumber { get; set; }
    public required int Reps { get; set; }
    public required decimal Weight { get; set; }
    public string? Comment { get; set; }
}

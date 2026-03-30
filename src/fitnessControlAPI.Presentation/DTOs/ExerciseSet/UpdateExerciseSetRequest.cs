namespace fitnessControlAPI.Presentation.DTOs.ExerciseSet;

public class UpdateExerciseSetRequest {
    public required Guid WorkoutExerciseId { get; set; }
    public required int SetNumber { get; set; }
    public required int Reps { get; set; }
    public required decimal Weight { get; set; }
    public string? Comment { get; set; }
}

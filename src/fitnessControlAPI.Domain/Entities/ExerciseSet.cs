namespace fitnessControlAPI.Domain.Entities;

public class ExerciseSet
{
    public Guid Id { get; set; }
    public required Guid WorkoutExerciseId { get; set; }
    public required int SetNumber { get; set; }
    public required int Reps { get; set; }
    public required decimal Weight { get; set; }
    public string WeightUnit { get; set; }
    public string? Comment { get; set; }
}
namespace fitnessControlAPI.Domain.Entities;

public class WorkoutExercise
{
    public Guid Id { get; set; }
    public required Guid WorkoutSessionId { get; set; }
    public required int ExerciseId { get; set; }
    public required int OrderNumber { get; set; }
    public string? Notes { get; set; }
}
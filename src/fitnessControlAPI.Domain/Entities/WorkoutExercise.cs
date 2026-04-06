namespace fitnessControlAPI.Domain.Entities;

public class WorkoutExercise
{
    public Guid Id { get; set; }
    public Guid WorkoutSessionId { get; set; }
    public required int ExerciseId { get; set; }
    public required int OrderNumber { get; set; }
    
    public WorkoutSession? WorkoutSession { get; set; }
    public Exercise? Exercise { get; set; }
    
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}

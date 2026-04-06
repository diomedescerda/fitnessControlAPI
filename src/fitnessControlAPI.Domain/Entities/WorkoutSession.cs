namespace fitnessControlAPI.Domain.Entities;

public class WorkoutSession
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required DateOnly Date { get; set; }
    public string? Notes { get; set; }
    
    public User? User { get; set; }
    
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}

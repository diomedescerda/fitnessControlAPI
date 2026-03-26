namespace fitnessControlAPI.Domain.Entities;

public class WorkoutSession
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required DateOnly SessionDate { get; set; }
    public string? Notes { get; set; }
}
namespace fitnessControlAPI.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Height { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<BodyMeasurement> BodyMeasurements { get; set; } = new List<BodyMeasurement>();
    public ICollection<RunningSession> RunningSessions { get; set; } = new List<RunningSession>();
    public ICollection<WorkoutSession>  WorkoutSessions { get; set; } = new List<WorkoutSession>();
}
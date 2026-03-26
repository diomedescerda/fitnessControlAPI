namespace fitnessControlAPI.Domain.Entities;

public class ExerciseCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
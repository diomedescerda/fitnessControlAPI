namespace fitnessControlAPI.Domain.Entities;

public class Exercise
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public bool IsCustom { get; set; }
}
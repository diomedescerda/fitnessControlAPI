namespace fitnessControlAPI.Presentation.DTOs.Exercise;

public class ExerciseResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public bool IsCustom { get; set; }
}

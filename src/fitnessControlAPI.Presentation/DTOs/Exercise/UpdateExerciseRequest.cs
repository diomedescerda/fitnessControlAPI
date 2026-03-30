namespace fitnessControlAPI.Presentation.DTOs.Exercise;

public class UpdateExerciseRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public bool IsCustom { get; set; }
}

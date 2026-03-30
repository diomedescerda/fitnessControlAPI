namespace fitnesControlAPI.Presentation.DTOs.ExerciseCategory;

public class ExerciseCategoryResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

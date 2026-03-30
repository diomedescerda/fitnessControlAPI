namespace fitnesControlAPI.Presentation.DTOs.ExerciseCategory;

public class UpdateExerciseCategoryRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}

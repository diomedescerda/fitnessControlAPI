namespace fitnesControlAPI.Presentation.DTOs.ExerciseCategory;

public class CreateExerciseCategoryRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}

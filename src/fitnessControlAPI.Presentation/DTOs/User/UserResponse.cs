namespace fitnessControlAPI.Presentation.DTOs.User;

public class UserResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Height { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
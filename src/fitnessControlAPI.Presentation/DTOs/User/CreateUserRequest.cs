namespace fitnessControlAPI.Presentation.DTOs.User;

public class CreateUserRequest
{
    public required string Name { get; set; }
    public decimal Height { get; set; }
    public DateTime BirthDate { get; set; }
}
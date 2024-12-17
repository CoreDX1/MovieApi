namespace Application.DTOs.User;

public record UserCreationDto(string Name, string Email, string Password_Hash);

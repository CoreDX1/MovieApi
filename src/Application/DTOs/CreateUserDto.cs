namespace Application.DTOs;

public record CreateUserDto(string Name, string Email, string Password_Hash);

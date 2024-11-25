namespace Application.DTOs;

public record UpdateCredentialDto(string Email, string OldPassword, string NewPassword);

namespace Application.DTOs.Credential;

public record UpdateCredentialDto(string Email, string OldPassword, string NewPassword);

namespace Application.DTOs.Credential;

public record CredentialUpdateDto(string Email, string OldPassword, string NewPassword);

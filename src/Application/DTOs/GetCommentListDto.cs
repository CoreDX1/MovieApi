namespace Application.DTOs;

public record GetCommentListDto(int Id, int MovieId, string Text, int UsuarioId, DateOnly Date);

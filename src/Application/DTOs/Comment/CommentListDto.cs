namespace Application.DTOs.Comment;

public record CommentListDto(int Id, int MovieId, string Text, int UsuarioId, DateOnly Date);

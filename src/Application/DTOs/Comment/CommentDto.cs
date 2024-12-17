namespace Application.DTOs.Comment;

public record CommentDto(int Id, int MovieId, string Text, DateOnly Date);

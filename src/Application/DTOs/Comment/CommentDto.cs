namespace Application.DTOs.Comment;

public record GetCommentDto(int Id, int MovieId, string Text, DateOnly Date);

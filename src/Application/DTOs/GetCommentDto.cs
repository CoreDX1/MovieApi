namespace Application.DTOs;

public record GetCommentDto(int Id, int MovieId, string Text, DateOnly Date);

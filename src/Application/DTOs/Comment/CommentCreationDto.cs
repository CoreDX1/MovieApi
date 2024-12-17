using System.Text.Json.Serialization;

namespace Application.DTOs.Comment;

public record CommentCreationDto
{
    public int MovieId { get; set; }
    public string Text { get; set; } = string.Empty;

    [JsonIgnore]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}

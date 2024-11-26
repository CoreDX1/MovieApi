using System.Text.Json.Serialization;

namespace Application.DTOs;

public record CreateCommentDto
{
    public int MovieId { get; set; }
    public string Text { get; set; } = string.Empty;

    [JsonIgnore]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}

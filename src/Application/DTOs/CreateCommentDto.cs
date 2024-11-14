using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.DTOs;

public class CreateCommentDto
{
    public int MovieId { get; set; }
    public string Text { get; set; } = string.Empty;

    [JsonIgnore]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateCommentDto, Comment>();
        }
    }
}

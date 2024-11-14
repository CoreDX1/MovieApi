using Domain.Entities;

namespace Application.DTOs;

public class GetCommentDto
{
    public int MovieId { get; set; }
    public string Text { get; set; } = null!;
    public DateOnly Date { get; set; }

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Comment, GetCommentDto>();
        }
    }
}

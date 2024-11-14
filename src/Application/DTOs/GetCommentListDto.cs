using Domain.Entities;

namespace Application.DTOs;

public class GetCommentListDto
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public DateOnly Date { get; set; }
    public string? MovieCode {get; set;}

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Comment, GetCommentListDto>();
        }
    }
}

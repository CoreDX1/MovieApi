using Domain.Entities;

namespace Application.Common.Models;

public record MovieDtoRequest
{
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public int Duration { get; set; } = 0;
    public string Genre { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MovieDtoRequest, Movie>();
        }
    }
}

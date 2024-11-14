using Domain.Entities;

namespace Application.DTOs;

public record GetMovieListDto(
    int Id,
    string Title,
    string Synopsis,
    int Year,
    int Duration,
    string Genre,
    string Image,
    string MovieCode
);

class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Movie, GetMovieListDto>();
    }
}

using Domain.Entities;

namespace Application.Common.Models;

public record MovieDtoResponse(
    int Id,
    string Title,
    string Synopsis,
    int Year,
    int Duration,
    string Genre,
    string Image
);

class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Movie, MovieDtoResponse>();
    }
}

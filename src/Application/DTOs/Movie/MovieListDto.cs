namespace Application.DTOs.Movie;

public record MovieListDto(
    int Id,
    string Title,
    string Synopsis,
    int Year,
    int Duration,
    string Genre,
    string Image,
    string MovieCode
);

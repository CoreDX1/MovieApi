namespace Application.DTOs;

public record GetMovieDto(
    int Id,
    string Title,
    string Synopsis,
    int Year,
    int Duration,
    string Genre,
    string Image
);

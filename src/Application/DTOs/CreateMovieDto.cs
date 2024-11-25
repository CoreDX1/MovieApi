namespace Application.DTOs;

public record CreateMovieDto(
    string Title,
    string Synopsis,
    int Year,
    int Duration,
    string Genre,
    string Image
);

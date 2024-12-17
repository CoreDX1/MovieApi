namespace Application.DTOs.Movie;

public record MovieDto(
    int Id,
    string Title,
    string Synopsis,
    int Year,
    int Duration,
    string Genre,
    string Image
);

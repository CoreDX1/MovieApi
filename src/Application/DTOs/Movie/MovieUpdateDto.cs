namespace Application.DTOs.Movie;

public class MovieUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public int Duration { get; set; } = 0;
    public string Synopsis { get; set; } = string.Empty;
}

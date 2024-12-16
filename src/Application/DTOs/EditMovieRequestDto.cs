namespace Application.DTOs;

public class EditMovieRequestDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public int Duration { get; set; } = 0;
    public string Synopsis { get; set; } = string.Empty;
}

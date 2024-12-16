namespace Domain.DTOs;

public class FilterMovie
{
    public string Title { get; set; } = string.Empty;
    public string OrderBy { get; set; } = "asc";
}

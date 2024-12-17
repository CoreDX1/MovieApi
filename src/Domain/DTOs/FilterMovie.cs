namespace Domain.DTOs;

public class FilterMovie
{
    public string Name { get; set; } = string.Empty;
    public string OrderBy { get; set; } = "asc";
}

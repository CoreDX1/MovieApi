namespace Domain.DTOs;

public class PaginatedList<T>
{
    public List<T> Item { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalPages { get; set; }
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
    public string Search { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string OrderBy { get; set; } = "asc";

    public PaginatedList()
    {
        Item = [];
        TotalPages = 10;
        Page = 1;
        PageSize = 10;
        Name = string.Empty;
        OrderBy = "asc";
    }
}

public class MovieFilterDto
{
    public string Name { get; set; } = string.Empty;
    public string OrderBy { get; set; } = "asc";
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Search { get; set; } = string.Empty;
}

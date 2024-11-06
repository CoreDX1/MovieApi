namespace Domain.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public string Text { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}

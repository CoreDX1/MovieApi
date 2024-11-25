namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string Text { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int? UsuarioId { get; set; }
    public virtual Movie Movie { get; set; }
}

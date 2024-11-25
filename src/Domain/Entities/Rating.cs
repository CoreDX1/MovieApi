namespace Domain.Entities;

public partial class Rating
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UsuarioId { get; set; }
    public int Rating1 { get; set; }

    public DateOnly Date { get; set; }

    public virtual Movie Movie { get; set; }
    public virtual Usuario Usuario { get; set; }
}

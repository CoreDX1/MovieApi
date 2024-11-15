namespace Domain.Entities;

public partial class UsuarioCredenciale
{
    public int UsuarioId { get; set; }

    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual Usuario Usuario { get; set; }
}

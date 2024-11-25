namespace Domain.Entities;

public class UsuarioCredenciale
{
    public int UsuarioId { get; set; }
    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime LastLogin { get; set; }

    public Usuario Usuario { get; set; }
}

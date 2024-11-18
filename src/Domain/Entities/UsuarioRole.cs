namespace Domain.Entities;

public class UsuarioRole
{
    public int UsuarioId { get; set; }
    public int RoleId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Role Role { get; set; }
    public Usuario Usuario { get; set; }
}

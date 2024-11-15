namespace Domain.Entities;

public partial class UsuarioRole
{
    public int UsuarioId { get; set; }

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Role Role { get; set; }

    public virtual Usuario Usuario { get; set; }
}

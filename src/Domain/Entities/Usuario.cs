namespace Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public virtual Usuario IdNavigation { get; set; }
    public virtual Usuario InverseIdNavigation { get; set; }
    public virtual ICollection<Rating> Ratings { get; set; } = [];
    public virtual UsuarioCredenciale UsuarioCredenciale { get; set; }
}

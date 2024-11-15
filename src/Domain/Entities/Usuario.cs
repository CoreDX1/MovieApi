namespace Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public virtual Usuario IdNavigation { get; set; }

    public virtual Usuario InverseIdNavigation { get; set; }
}

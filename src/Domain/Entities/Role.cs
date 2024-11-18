
namespace Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Role IdNavigation { get; set; }
    public Role InverseIdNavigation { get; set; }
}

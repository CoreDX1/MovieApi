namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User IdNavigation { get; set; }
    public User InverseIdNavigation { get; set; }

    public ICollection<Comment> Roles { get; set; } = [];
    public ICollection<Comment> Comments { get; set; }
}

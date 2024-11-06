namespace Domain.Entities;

public partial class Actor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

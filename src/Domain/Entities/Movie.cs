namespace Domain.Entities;

public partial class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Synopsis { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; } = null!;
    public string? Image { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
    public virtual ICollection<Director> Directors { get; set; } = new List<Director>();
}

﻿namespace Domain.Entities;

public class Movie
{
    public Movie() { }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public string Image { get; set; }
    public string MovieCode { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
    public virtual ICollection<Director> Directors { get; set; } = new List<Director>();
}

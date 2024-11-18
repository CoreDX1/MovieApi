﻿namespace Domain.Entities;

public class Movie
{

    public Movie(){}

    public int Id { get; set; }
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public string Image { get; set; }
    public string MovieCode { get; set; }

    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Actor> Actors { get; set; } = [];
    public ICollection<Director> Directors { get; set; } = [];
}

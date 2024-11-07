using AutoMapper;
using Domain.Entities;

namespace Application.Common.Models;

public class MovieDtoResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Synopsis { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public string? Genre { get; set; }
    public string? Image { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Movie, MovieDtoResponse>();
        }
    }
}

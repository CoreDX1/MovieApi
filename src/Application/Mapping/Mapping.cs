using Application.DTOs.Comment;
using Application.DTOs.Movie;
using Application.DTOs.User;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Mapping;

public class Mapping : Profile
{
    public Mapping()
    {
        // Response
        CreateMap<Movie, MovieListDto>();
        CreateMap<Movie, MovieDto>();
        CreateMap<Comment, CommentDto>();
        CreateMap<Comment, CommentListDto>();
        CreateMap<Usuario, UsuarioWithCommentsDto>();
        CreateMap<Usuario, UserDto>();
        CreateMap<Usuario, UsuarioCredenciale>();

        // Request
        CreateMap<CommentCreationDto, Comment>();
        CreateMap<MovieCreationDto, Movie>();
        CreateMap<UserCreationDto, Usuario>();
        CreateMap<UserLoginDto, Usuario>();
        CreateMap<MovieUpdateDto, Movie>();
    }
}

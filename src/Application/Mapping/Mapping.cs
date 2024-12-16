using Application.DTOs;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Mapping;

public class Mapping : Profile
{
    public Mapping()
    {
        // Response
        CreateMap<Movie, GetMovieListDto>();
        CreateMap<Movie, GetMovieDto>();
        CreateMap<Comment, GetCommentDto>();
        CreateMap<Comment, GetCommentListDto>();
        CreateMap<Usuario, UsuarioWithCommentsDto>();
        CreateMap<Usuario, GetUserDto>();
        CreateMap<Usuario, UsuarioCredenciale>();

        // Request
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<CreateUserDto, Usuario>();
        CreateMap<LoginUserDto, Usuario>();
        CreateMap<EditMovieRequestDto, Movie>();
    }
}

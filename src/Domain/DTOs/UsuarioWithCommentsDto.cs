using AutoMapper;

namespace Domain.DTOs;

public class UsuarioWithCommentsDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Comment { get; set; }

    public DateOnly Date { get; set; }

    public class Mapper : Profile
    {
    }
}

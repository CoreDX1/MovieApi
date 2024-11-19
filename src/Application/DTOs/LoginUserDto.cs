using Domain.Entities;

namespace Application.DTOs;

public class LoginUserDto
{
    public string Email { get; set; } = string.Empty;
    public string Password_Hash { get; set; } = string.Empty;

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<LoginUserDto, User>();
        }
    }
}

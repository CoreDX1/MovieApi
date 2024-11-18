using Domain.Entities;

namespace Application.DTOs;

public class GetUserListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, GetUserListDto>();
        }
    }
}

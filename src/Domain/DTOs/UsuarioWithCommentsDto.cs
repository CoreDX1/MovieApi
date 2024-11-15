using Domain.Entities;

namespace Domain.DTOs;

public class UsuarioWithCommentsDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateOnly Date { get; set; }
    public Comment Comments { get; set; }
}

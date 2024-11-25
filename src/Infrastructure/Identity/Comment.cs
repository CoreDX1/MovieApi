using System;
using System.Collections.Generic;

namespace Infrastructure.Identity;

public partial class Comment
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public string Text { get; set; }

    public DateOnly Date { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Movie Movie { get; set; }
}

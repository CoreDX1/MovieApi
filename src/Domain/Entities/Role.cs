﻿
namespace Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual Role IdNavigation { get; set; }

    public virtual Role InverseIdNavigation { get; set; }
}

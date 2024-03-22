using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Rol
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

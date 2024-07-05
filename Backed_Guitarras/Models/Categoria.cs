using System;
using System.Collections.Generic;

namespace Backed_Guitarras.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Guitarra> Guitarras { get; set; } = new List<Guitarra>();
}

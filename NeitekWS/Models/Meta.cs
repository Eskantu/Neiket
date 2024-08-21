using System;
using System.Collections.Generic;

namespace NeitekWS.Models;

public partial class Meta
{
    public int PkMeta { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }
}

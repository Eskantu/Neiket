using System;
using System.Collections.Generic;

namespace NeitekWS.Models;

public partial class MetasView
{
    public int? PkMeta { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int TotalTareasByMeta { get; set; }

    public int Completas { get; set; }

    public decimal Porcentaje { get; set; }
}

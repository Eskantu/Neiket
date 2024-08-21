using System;
using System.Collections.Generic;

namespace NeitekWS.Models;

public partial class Tarea
{
    public int PkTarea { get; set; }

    public string NombreTarea { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public bool Completada { get; set; }

    public int FkMeta { get; set; }

    public bool Importante { get; set; }
}

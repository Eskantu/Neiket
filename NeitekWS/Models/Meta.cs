using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace NeitekWS.Models;

public partial class Meta
{
    private readonly NeitekContext _context;
    public Meta(NeitekContext context)
    {
        _context = context;
    }
    public int PkMeta { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public virtual ICollection<Tarea> Tareas
    {
        get; set;
    } = new List<Tarea>();
}

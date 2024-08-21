
using Neitek.Services.Tareas;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Neitek.services.Metas;

public partial class Meta
{
    [JsonPropertyName("pkMeta")]
    public int? PkMeta { get; set; }
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }
    [JsonPropertyName("fechaCreacion")]
    public DateOnly FechaCreacion { get; set; }
    [JsonPropertyName("tareas")]
    public virtual List<Tarea> Tareas
    {
        get; set;
    } = new List<Tarea>();
}

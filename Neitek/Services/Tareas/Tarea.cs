using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Neitek.Services.Tareas
{
    public partial class Tarea
    {
        [JsonPropertyName("pkTarea")]
        public int? PkTarea { get; set; }

        [JsonPropertyName("nombreTarea")]
        public string NombreTarea { get; set; } = null!;

        [JsonPropertyName("fechaCreacion")]
        public DateOnly FechaCreacion { get; set; }

        [JsonPropertyName("completada")]
        public bool Completada { get; set; }

        [JsonPropertyName("fkMeta")]
        public int? FkMeta { get; set; }

        [JsonPropertyName("importante")]
        public bool Importante { get; set; }
    }
}

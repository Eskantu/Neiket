using System.Text.Json.Serialization;

namespace Neitek.services.Metas
{
    public class MetasView
    {
        [JsonPropertyName("pkMeta")]
        public int? PkMeta { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateOnly? FechaCreacion { get; set; }
        [JsonPropertyName("totalTareasByMeta")]
        public int TotalTareasByMeta { get; set; }
        [JsonPropertyName("porcentaje")]
        public decimal Porcentaje { get; set; }
        [JsonPropertyName("completas")]
        public int Completas { get; set; }
    }
}

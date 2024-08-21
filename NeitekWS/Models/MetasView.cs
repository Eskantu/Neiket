namespace NeitekWS.Models
{
    public class MetasView
    {
        private readonly NeitekContext _context;
        public MetasView(NeitekContext context) => _context = context;
        public int PkMeta { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public int TotalTareasByMeta { get; set; }
        public decimal Porcentaje { get; set; }
        public int Completas { get; set; }
    }
}

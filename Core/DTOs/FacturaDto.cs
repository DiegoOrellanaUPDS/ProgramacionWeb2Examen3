namespace ExamenFinalProgramacionWeb2.Core.DTOs
{
    public class FacturaDto
    {
        public int Codigo { get; set; }
        public int ClienteCi { get; set; }
        public DateOnly Fecha { get; set; }
        public int MontoTotal { get; set; }
        public bool Pagada { get; set; }
    }
}

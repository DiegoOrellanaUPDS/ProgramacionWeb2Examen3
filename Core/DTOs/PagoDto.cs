namespace ExamenFinalProgramacionWeb2.Core.DTOs
{
    public class PagoDto
    {
        public int Codigo { get; set; }
        public int FacturaCodigo { get; set; }
        public DateOnly FechaPago { get; set; }
        public int MontoPagado { get; set; }
    }
}

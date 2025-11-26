using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Entidades
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public DateOnly FechaPago { get; set; }
        public int MontoPagado { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}

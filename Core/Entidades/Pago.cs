using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Core.Entidades
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int FacturaCodigo { get; set; }
        public DateOnly FechaPago { get; set; }
        public int MontoPagado { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}

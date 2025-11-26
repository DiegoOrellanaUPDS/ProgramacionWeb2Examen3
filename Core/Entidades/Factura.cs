using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Core.Entidades
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int ClienteCi { get; set; }
        public DateOnly Fecha { get; set; }
        public int MontoTotal { get; set; }
        public bool Pagada { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}

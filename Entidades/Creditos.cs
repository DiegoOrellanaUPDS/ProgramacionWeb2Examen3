using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Entidades
{
    public class Credito
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int LimiteCredito { get; set; }
        public int SaldoUsado { get; set; }
        public string Estado { get; set; } = "Activo";
    }

}

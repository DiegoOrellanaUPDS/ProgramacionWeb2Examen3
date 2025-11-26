using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Core.Entidades
{
    public class Credito
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int ClienteCi { get; set; }
        public int LimiteCredito { get; set; }
        public int SaldoUsado { get; set; }
        public string Estado { get; set; } = "Activo";
    }

}

using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Core.Entidades
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ci { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; } = "Activo";
    }

}

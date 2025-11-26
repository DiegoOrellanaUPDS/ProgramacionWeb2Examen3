using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Core.Entidades
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public float Calificacion { get; set; }
        public string Estado { get; set; } = "Activo";

    }

}

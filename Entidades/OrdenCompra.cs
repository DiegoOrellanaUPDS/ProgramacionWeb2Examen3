using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgramacionWeb2.Entidades
{
    public class OrdenCompra
    {
        [Key]
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public DateOnly Fecha { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int CostoTotal { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}

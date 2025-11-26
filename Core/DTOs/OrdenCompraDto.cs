namespace ExamenFinalProgramacionWeb2.Core.DTOs
{
    public class OrdenCompraDto
    {
        public int Codigo { get; set; }
        public int ProveedorCodigo { get; set; }
        public DateOnly Fecha { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int CostoTotal { get; set; }
    }
}

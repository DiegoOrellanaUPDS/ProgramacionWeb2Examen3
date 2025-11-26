using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Core.Mapeador
{
    public static class OrdenCompraMapeador
    {
        public static OrdenCompraDto ToDto(this OrdenCompra ordencompra)
        {
            return new OrdenCompraDto
            {
                Codigo = ordencompra.Codigo,
                ProveedorCodigo = ordencompra.Codigo,
                Fecha = ordencompra.Fecha,
                Producto = ordencompra.Producto,
                Cantidad = ordencompra.Cantidad,
                CostoTotal = ordencompra.CostoTotal
            };
        }
        public static OrdenCompra ToEntidad(this OrdenCompraDto ordencompradto)
        {
            return new OrdenCompra
            {
                Codigo = ordencompradto.Codigo,
                ProveedorCodigo = ordencompradto.ProveedorCodigo,
                Fecha = ordencompradto.Fecha,
                Producto = ordencompradto.Producto,
                Cantidad = ordencompradto.Cantidad,
                CostoTotal = ordencompradto.CostoTotal,
                Estado = "Activo"
            };
        }
    }
}

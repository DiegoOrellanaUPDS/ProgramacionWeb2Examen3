using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Core.Mapeador
{
    public static class FacturaMapeador
    {
        public static FacturaDto ToDto(this Factura factura)
        {
            return new FacturaDto
            {
                Codigo = factura.Codigo,
                ClienteCi = factura.ClienteCi,
                MontoTotal = factura.MontoTotal,
            };
        }
        public static Factura ToEntidad(this FacturaDto facturadto)
        {
            return new Factura
            {
                Codigo = facturadto.Codigo,
                ClienteCi = facturadto.ClienteCi,
                MontoTotal = facturadto.MontoTotal,
                Estado = "Activo"
            };
        }
    }
}

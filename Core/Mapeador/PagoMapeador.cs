using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Core.Mapeador
{
    public static class PagoMapeador
    {
        public static PagoDto ToDto(this Pago pago)
        {
            return new PagoDto
            {
                Codigo = pago.Codigo,
                FacturaCodigo = pago.FacturaCodigo,
                FechaPago = pago.FechaPago,
                MontoPagado = pago.MontoPagado
            };
        }
        public static Pago ToEntity(this PagoDto pagoDto)
        {
            return new Pago
            {
                Codigo = pagoDto.Codigo,
                FacturaCodigo = pagoDto.FacturaCodigo,
                FechaPago = pagoDto.FechaPago,
                MontoPagado = pagoDto.MontoPagado,
                Estado = "Activo"
            };
        }
    }
}
